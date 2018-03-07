using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SearchDev
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public List<netCard> allCards = new List<netCard>();

        private UdpClient receiveUdpClient;

        private string GroupIp = "224.1.1.1";
        private int GroupEndPort = 65000;//目标端口
        private int GroupReceivePort = 65000;//接收端口
        // 组播IP地址
        IPEndPoint broadcastIpEndPoint;

        Thread threadReceive = null;

        private bool isReceiveJoinGtoup = true;//接收来自组播的信息

        private string currentLocalIPV4 = "";

        private List<deviceInfo> DeviceList = new List<deviceInfo>();//设备列表
        private BindingList<deviceInfo> BindDeviceList;

        private ChangeDevIPData CurrentDev;
        private int selectDevIndex = -1;

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadAllNetCards();
            foreach (var item in allCards)
            {
                comb_netCard.Items.Add(item.Name);
            }
            if (comb_netCard.Items.Count > 0)
                comb_netCard.SelectedIndex = 0;
            //
            currentLocalIPV4 = GetLocalIP();


            BindDeviceList = new BindingList<deviceInfo>(DeviceList);

            //将DataGridView里的数据源绑定成BindingList

            this.dGrid_devList.DataSource = BindDeviceList;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadReceive != null)
            {
                receiveUdpClient.Close();
                threadReceive.Abort();
            }
        }

        private void loadAllNetCards()
        {
            //获取说有网卡信息
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in nics)
            {
                //判断是否为以太网卡
                //Wireless80211         无线网卡    Ppp     宽带连接
                //Ethernet              以太网卡   
                //这里篇幅有限贴几个常用的，其他的返回值大家就自己百度吧！
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //获取以太网卡网络接口信息
                    IPInterfaceProperties ip = adapter.GetIPProperties();

                    //获取单播地址集
                    UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;

                    //获取该IP对象的网关
                    GatewayIPAddressInformationCollection gateways = ip.GatewayAddresses;

                    foreach (UnicastIPAddressInformation ipadd in ipCollection)
                    {
                        netCard oneCard = new netCard();

                        foreach (var gateWay in gateways)
                        {
                            //如果能够Ping通网关
                            if (IsPingIP(gateWay.Address.ToString()))
                            {
                                //得到网关地址
                                oneCard.Gateway = gateWay.Address.ToString();
                                //跳出循环
                                break;
                            }
                        }

                        //InterNetwork    IPV4地址      
                        //InterNetworkV6        IPV6地址
                        //Max            MAX 位址
                        //判断是否为ipv4
                        if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
                        {

                            oneCard.Name = adapter.Name;
                            if (ip.DnsAddresses[0] != null)
                                oneCard.DNS = ip.DnsAddresses[0].ToString();

                            oneCard.IPV4 = ipadd.Address.ToString();//获取ip
                            if (ipadd.IPv4Mask != null)
                                oneCard.SubnetMask = ipadd.IPv4Mask.ToString();

                            allCards.Add(oneCard);
                        }
                    }
                }
            }
        }

        /// 尝试Ping指定IP是否能够Ping通      
        /// <param name="strIP">指定IP</param>
        /// <returns>true 是 false 否</returns>
        public static bool IsPingIP(string strIP)
        {
            try
            {
                Ping ping = new Ping();
                IPAddress ip;
                if (!IPAddress.TryParse(strIP, out ip))
                {
                    return false;
                }
                //接受Ping返回值
                PingReply reply = ping.Send(strIP, 1000);
                //Ping通
                return true;
            }
            catch
            {
                //Ping失败
                return false;
            }
        }

        /// <summary>  
        /// 获取当前使用的IP  
        /// </summary>  
        /// <returns></returns>  
        public static string GetLocalIP()
        {
            string result = RunApp("route", "print", true);
            Match m = Regex.Match(result, @"0.0.0.0\s+0.0.0.0\s+(\d+.\d+.\d+.\d+)\s+(\d+.\d+.\d+.\d+)");
            if (m.Success)
            {
                return m.Groups[2].Value;
            }
            else
            {
                try
                {
                    System.Net.Sockets.TcpClient c = new System.Net.Sockets.TcpClient();
                    c.Connect("www.baidu.com", 80);
                    string ip = ((System.Net.IPEndPoint)c.Client.LocalEndPoint).Address.ToString();
                    c.Close();
                    return ip;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>  
        /// 获取本机主DNS  
        /// </summary>  
        /// <returns></returns>  
        public static string GetPrimaryDNS()
        {
            string result = RunApp("nslookup", "", true);
            Match m = Regex.Match(result, @"\d+\.\d+\.\d+\.\d+");
            if (m.Success)
            {
                return m.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>  
        /// 运行一个控制台程序并返回其输出参数。  
        /// </summary>  
        /// <param name="filename">程序名</param>  
        /// <param name="arguments">输入参数</param>  
        /// <returns></returns>  
        public static string RunApp(string filename, string arguments, bool recordLog)
        {
            try
            {
                if (recordLog)
                {
                    Trace.WriteLine(filename + " " + arguments);
                }
                Process proc = new Process();
                proc.StartInfo.FileName = filename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(proc.StandardOutput.BaseStream, Encoding.Default))
                {
                    //string txt = sr.ReadToEnd();  
                    //sr.Close();  
                    //if (recordLog)  
                    //{  
                    //    Trace.WriteLine(txt);  
                    //}  
                    //if (!proc.HasExited)  
                    //{  
                    //    proc.Kill();  
                    //}  
                    //上面标记的是原文，下面是我自己调试错误后自行修改的  
                    Thread.Sleep(100);           //貌似调用系统的nslookup还未返回数据或者数据未编码完成，程序就已经跳过直接执行  
                                                 //txt = sr.ReadToEnd()了，导致返回的数据为空，故睡眠令硬件反应  
                    if (!proc.HasExited)         //在无参数调用nslookup后，可以继续输入命令继续操作，如果进程未停止就直接执行  
                    {                            //txt = sr.ReadToEnd()程序就在等待输入，而且又无法输入，直接掐住无法继续运行  
                        proc.Kill();
                    }
                    string txt = sr.ReadToEnd();
                    sr.Close();
                    if (recordLog)
                        Trace.WriteLine(txt);
                    return txt;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return ex.Message;
            }
        }

        private void comb_netCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_NetCardIPV4.Text = allCards[comb_netCard.SelectedIndex].IPV4;
            txt_netCardMask.Text = allCards[comb_netCard.SelectedIndex].SubnetMask;
            txt_NetCardGateway.Text = allCards[comb_netCard.SelectedIndex].Gateway;
            txt_NetCardDNS.Text = allCards[comb_netCard.SelectedIndex].DNS;
        }

        // 发送组播消息
        private void groupSendData(string data)
        {
            // 组播模式
            broadcastIpEndPoint = new IPEndPoint(IPAddress.Parse(GroupIp), GroupEndPort);
            // 启动发送线程发送消息
            Thread sendThread = new Thread(SendMessage);
            sendThread.IsBackground = true;
            sendThread.Start(data);
        }

        // 发送消息线程方法
        private void SendMessage(object obj)
        {
            byte[] messagebytes = Encoding.UTF8.GetBytes(obj.ToString());

            using (var sendUdpClient = new UdpClient())
            {
                // 发送消息到组播或广播地址
                int state = sendUdpClient.Send(messagebytes, messagebytes.Length, broadcastIpEndPoint);

                sendUdpClient.Close();
            }
        }

        string receiveMessageStr = "";
        string msgShow = "";

        // 接收消息线程方法
        private void ReceiveMessage()
        {
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                string receiveMessage = "";
                try
                {
                    //关闭receiveUdpClient时此时会产生异常
                    byte[] receiveBytes = receiveUdpClient.Receive(ref remoteIpEndPoint);
                    if (remoteIpEndPoint.Address.ToString() == currentLocalIPV4)
                    {
                        continue;
                    }
                    receiveMessage = Encoding.UTF8.GetString(receiveBytes);
                    receiveMessageStr = receiveMessage;
                    //分析信息内容
                    // displayReceiveedMsg();
                    //显示信息
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
                try
                {
                    if (receiveMessage != "")
                    {
                        //检查是否是设置设备IP后的返回信息。
                        if (CurrentDev != null)
                        {
                            SetIPResult result = JsonConvert.DeserializeObject<SetIPResult>(receiveMessage);

                            if (result.SN == CurrentDev.SN && result.Status)
                            {
                                msgShow = "参数修改成功!";
                                displayReceiveedMsg();
                            }
                        }
                        else
                        {
                            bool ex = false;
                            deviceInfo oneDev = JsonConvert.DeserializeObject<deviceInfo>(receiveMessage);
                            foreach (var one in BindDeviceList)
                            {
                                if (one.SN == oneDev.SN)
                                {
                                    ex = true;
                                    break;
                                }
                            }
                            if (this.dGrid_devList.IsHandleCreated && !ex && oneDev.SN.Length > 0)
                                this.dGrid_devList.BeginInvoke(new Action(delegate
                                {
                                    //发送到UI 线程执行的代码
                                    BindDeviceList.Add(oneDev);
                                    lab_devCount.Text = BindDeviceList.Count.ToString();
                                }));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
        }

        private void displayReceiveedMsg()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(this.displayReceiveedMsg));//检查是否需要委托执行
            }
            else
            {
                BindDeviceList[selectDevIndex].AliasName = CurrentDev.aliasName;
                BindDeviceList[selectDevIndex].IPV4 = CurrentDev.newIP;
                BindDeviceList[selectDevIndex].SubnetMask = CurrentDev.newmask;
                BindDeviceList[selectDevIndex].Gateway = CurrentDev.newgateway;
                BindDeviceList[selectDevIndex].DNS = CurrentDev.newdnsweb;
                BindDeviceList[selectDevIndex].IsDHCP = CurrentDev.Switch;
                this.dGrid_devList.Refresh();
                //实际的执行程序体
                MessageBox.Show(msgShow);
                CurrentDev = null;
            }
        }

        // 启动接收消息
        private void startReceiveData()
        {
            if (threadReceive != null)
            {
                receiveUdpClient.Close();
                threadReceive.Abort();
                threadReceive = null;
            }

            //判断IP是否有效
            currentLocalIPV4 = GetLocalIP();
            // 创建接收套接字
            IPAddress localIp = IPAddress.Parse(currentLocalIPV4);//选定当前系统的IP
            IPEndPoint localIpEndPoint = new IPEndPoint(localIp, GroupReceivePort);
            receiveUdpClient = new UdpClient(localIpEndPoint);
            // 加入组播组接收组播信息
            //！！！考虑不接受组播信息
            if (isReceiveJoinGtoup)
            {
                receiveUdpClient.JoinMulticastGroup(IPAddress.Parse(GroupIp));
                receiveUdpClient.Ttl = 50;
            }

            // 启动接受线程
            threadReceive = new Thread(ReceiveMessage);
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }

        public string HttpGet(string Url, Dictionary<string, string> parameters)
        {
            //拼装请求参数列表  
            StringBuilder sb = new StringBuilder();
            string strParameters = "";
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("&");
                    }
                    sb.AppendFormat("{0}={1}", kvp.Key, kvp.Value);
                }
                strParameters = sb.ToString();
            }
            MessageBox.Show(strParameters);
            string retString = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (strParameters == "" ? "" : "?") + strParameters);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("网络错误：" + ex.Message);
                throw (ex);
            }
            return retString;
        }

        /// <summary>
        /// 开始搜索设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SearchDev_Click(object sender, EventArgs e)
        {
            BindDeviceList.Clear();//清除既有设备数据
            CurrentDev = null;//清除设置设备ip命令标志
            lab_devCount.Text = "0";
           var localIP = GetLocalIP();//获取电脑当前本地IP

            SearchCmd cmd = new SearchCmd("SearchDev", localIP);
            var searchCMD = JsonConvert.SerializeObject(cmd);

            startReceiveData();//启动接收消息
            groupSendData(searchCMD);//发送查询信息到设备组

        }

        private void btn_openFromWeb_Click(object sender, EventArgs e)
        {
            //调用系统默认的浏览器   
            System.Diagnostics.Process.Start(String.Format("http://{0}", txt_devIPV4.Text));
        }

        private void btn_changeDevNet_Click(object sender, EventArgs e)
        {
            //参数验证
            IPAddress ip;
            if (!IPAddress.TryParse(txt_devIPV4.Text, out ip))
            {
                MessageBox.Show(txt_devIPV4.Text + "  IP 地址不正确!");
                txt_devIPV4.Focus();
                return;
            }
            if (!IPAddress.TryParse(txt_devMask.Text, out ip))
            {
                MessageBox.Show(txt_devMask.Text + "  子网掩码不正确!");
                txt_devMask.Focus();
                return;
            }
            if (!IPAddress.TryParse(txt_devGatway.Text, out ip))
            {
                MessageBox.Show(txt_devGatway.Text + "  网关地址不正确!");
                txt_devGatway.Focus();
                return;
            }
            if (!IPAddress.TryParse(txt_devDNS.Text, out ip))
            {
                MessageBox.Show(txt_devDNS.Text + "  IP 地址不正确!");
                txt_devDNS.Focus();
                return;
            }
            //生成参数

            ChangeDevIPData parameters = new ChangeDevIPData();
            CurrentDev = parameters;
            if (BindDeviceList.Count < 1)
            {
                MessageBox.Show("请先搜索并选择需要修改网络配置的设备!");
                return;
            }
            parameters.SN = BindDeviceList[selectDevIndex].SN;//获取选择设备的SN
            parameters.Switch = chk_isDevDHCP.Checked;//
            parameters.newIP = txt_devIPV4.Text;
            parameters.newmask = txt_devMask.Text;
            parameters.newgateway = txt_devGatway.Text;
            parameters.newdnsweb = txt_devDNS.Text;
            parameters.aliasName = txt_devAliasName.Text;
            parameters.userName = txt_userName.Text;
            parameters.password = txt_password.Text;

            try
            {
                string cmdStr = JsonConvert.SerializeObject(parameters);
                groupSendData(cmdStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改网络参数发生错误：" + ex.Message);
            }
        }

        private void btn_referencePC_Click(object sender, EventArgs e)
        {
            txt_devIPV4.Text = txt_NetCardIPV4.Text;
            txt_devMask.Text = txt_netCardMask.Text;
            txt_devGatway.Text = txt_NetCardGateway.Text;
            txt_devDNS.Text = txt_NetCardDNS.Text;

        }

        private void dGrid_devList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectDevIndex = -1;
            if (e.RowIndex >= 0 && BindDeviceList.Count > 0)
            {
                selectDevIndex = e.RowIndex;
                txt_devIPV4.Text = BindDeviceList[e.RowIndex].IPV4;
                txt_devMask.Text = BindDeviceList[e.RowIndex].SubnetMask;
                txt_devGatway.Text = BindDeviceList[e.RowIndex].Gateway;
                txt_devDNS.Text = BindDeviceList[e.RowIndex].DNS;
                txt_devAliasName.Text = BindDeviceList[e.RowIndex].AliasName;
                chk_isDevDHCP.Checked = BindDeviceList[e.RowIndex].IsDHCP;
            }
        }
    }


    public struct netCard
    {
        public string Name;
        public string IPV4;
        public string IPV6;
        public string SubnetMask;
        public string Gateway;
        public string DNS;
    }

    public class deviceInfo
    {
        public string AliasName { get; set; }
        public string Type { get; set; }
        public string HardwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string SN { get; set; }

        public bool IsDHCP { get; set; }
        public string IPV4 { get; set; }
        public string SubnetMask { get; set; }
        public string Gateway { get; set; }
        public string DNS { get; set; }

        public deviceInfo() { }

    }

    public class SearchCmd
    {
        public string CMD;
        public string InquirersIPV4;

        public SearchCmd(string cmd, string ip)
        {
            CMD = cmd;
            InquirersIPV4 = ip;
        }
    }

    public class ChangeDevIPData
    {
        public string CMD = "ChangeNet";
        public string SN;
        public bool Switch;
        public string newIP;
        public string newmask;
        public string newgateway;
        public string newdnsweb;
        public string aliasName;
        public string userName;
        public string password;
    }

    public class SetIPResult
    {
        public bool Status;
        public int StatusCode;//
        public string SN;
        public string StatusMessage;// UserName or password error.
    }
}

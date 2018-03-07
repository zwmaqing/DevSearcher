namespace SearchDev
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lab_devCount = new System.Windows.Forms.Label();
            this.btn_SearchDev = new System.Windows.Forms.Button();
            this.dGrid_devList = new System.Windows.Forms.DataGridView();
            this.AliasName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HardwareVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoftwareVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPV4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_devDNS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_devGatway = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_devMask = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_devIPV4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_devAliasName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_isDevDHCP = new System.Windows.Forms.CheckBox();
            this.btn_changeDevNet = new System.Windows.Forms.Button();
            this.btn_openFromWeb = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_referencePC = new System.Windows.Forms.Button();
            this.txt_NetCardDNS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_NetCardGateway = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_netCardMask = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_NetCardIPV4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comb_netCard = new System.Windows.Forms.ComboBox();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_devList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "在线设备总数:";
            // 
            // lab_devCount
            // 
            this.lab_devCount.AutoSize = true;
            this.lab_devCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_devCount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lab_devCount.Location = new System.Drawing.Point(122, 4);
            this.lab_devCount.Name = "lab_devCount";
            this.lab_devCount.Size = new System.Drawing.Size(20, 22);
            this.lab_devCount.TabIndex = 1;
            this.lab_devCount.Text = "0";
            // 
            // btn_SearchDev
            // 
            this.btn_SearchDev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_SearchDev.Location = new System.Drawing.Point(510, 4);
            this.btn_SearchDev.Name = "btn_SearchDev";
            this.btn_SearchDev.Size = new System.Drawing.Size(75, 23);
            this.btn_SearchDev.TabIndex = 2;
            this.btn_SearchDev.Text = "搜索设备";
            this.btn_SearchDev.UseVisualStyleBackColor = false;
            this.btn_SearchDev.Click += new System.EventHandler(this.btn_SearchDev_Click);
            // 
            // dGrid_devList
            // 
            this.dGrid_devList.AllowUserToAddRows = false;
            this.dGrid_devList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid_devList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AliasName,
            this.Type,
            this.HardwareVersion,
            this.SoftwareVersion,
            this.SN,
            this.IPV4});
            this.dGrid_devList.Location = new System.Drawing.Point(12, 29);
            this.dGrid_devList.MultiSelect = false;
            this.dGrid_devList.Name = "dGrid_devList";
            this.dGrid_devList.ReadOnly = true;
            this.dGrid_devList.RowHeadersVisible = false;
            this.dGrid_devList.RowTemplate.Height = 26;
            this.dGrid_devList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGrid_devList.ShowEditingIcon = false;
            this.dGrid_devList.Size = new System.Drawing.Size(710, 541);
            this.dGrid_devList.TabIndex = 3;
            this.dGrid_devList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGrid_devList_CellClick);
            // 
            // AliasName
            // 
            this.AliasName.DataPropertyName = "AliasName";
            this.AliasName.HeaderText = "设备别名";
            this.AliasName.Name = "AliasName";
            this.AliasName.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // HardwareVersion
            // 
            this.HardwareVersion.DataPropertyName = "HardwareVersion";
            this.HardwareVersion.HeaderText = "硬件版本";
            this.HardwareVersion.Name = "HardwareVersion";
            this.HardwareVersion.ReadOnly = true;
            // 
            // SoftwareVersion
            // 
            this.SoftwareVersion.DataPropertyName = "SoftwareVersion";
            this.SoftwareVersion.HeaderText = "软件版本";
            this.SoftwareVersion.Name = "SoftwareVersion";
            this.SoftwareVersion.ReadOnly = true;
            // 
            // SN
            // 
            this.SN.DataPropertyName = "SN";
            this.SN.HeaderText = "序列号";
            this.SN.Name = "SN";
            this.SN.ReadOnly = true;
            // 
            // IPV4
            // 
            this.IPV4.DataPropertyName = "IPV4";
            this.IPV4.HeaderText = "IP地址";
            this.IPV4.Name = "IPV4";
            this.IPV4.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_userName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_devDNS);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_devGatway);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_devMask);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_devIPV4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_devAliasName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chk_isDevDHCP);
            this.groupBox1.Location = new System.Drawing.Point(728, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 276);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络参数修改";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(93, 243);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(114, 21);
            this.txt_password.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "密码：";
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(93, 209);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(114, 21);
            this.txt_userName.TabIndex = 12;
            this.txt_userName.Text = "admin";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "用户名：";
            // 
            // txt_devDNS
            // 
            this.txt_devDNS.Location = new System.Drawing.Point(93, 176);
            this.txt_devDNS.Name = "txt_devDNS";
            this.txt_devDNS.Size = new System.Drawing.Size(114, 21);
            this.txt_devDNS.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "DNS：";
            // 
            // txt_devGatway
            // 
            this.txt_devGatway.Location = new System.Drawing.Point(93, 140);
            this.txt_devGatway.Name = "txt_devGatway";
            this.txt_devGatway.Size = new System.Drawing.Size(114, 21);
            this.txt_devGatway.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "网关：";
            // 
            // txt_devMask
            // 
            this.txt_devMask.Location = new System.Drawing.Point(93, 105);
            this.txt_devMask.Name = "txt_devMask";
            this.txt_devMask.Size = new System.Drawing.Size(114, 21);
            this.txt_devMask.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "子网掩码：";
            // 
            // txt_devIPV4
            // 
            this.txt_devIPV4.Location = new System.Drawing.Point(93, 73);
            this.txt_devIPV4.Name = "txt_devIPV4";
            this.txt_devIPV4.Size = new System.Drawing.Size(114, 21);
            this.txt_devIPV4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "IP地址：";
            // 
            // txt_devAliasName
            // 
            this.txt_devAliasName.Location = new System.Drawing.Point(93, 40);
            this.txt_devAliasName.Name = "txt_devAliasName";
            this.txt_devAliasName.Size = new System.Drawing.Size(114, 21);
            this.txt_devAliasName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "设备别名：";
            // 
            // chk_isDevDHCP
            // 
            this.chk_isDevDHCP.AutoSize = true;
            this.chk_isDevDHCP.Location = new System.Drawing.Point(93, 17);
            this.chk_isDevDHCP.Name = "chk_isDevDHCP";
            this.chk_isDevDHCP.Size = new System.Drawing.Size(72, 16);
            this.chk_isDevDHCP.TabIndex = 0;
            this.chk_isDevDHCP.Text = "使用DHCP";
            this.chk_isDevDHCP.UseVisualStyleBackColor = true;
            // 
            // btn_changeDevNet
            // 
            this.btn_changeDevNet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_changeDevNet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_changeDevNet.Location = new System.Drawing.Point(742, 294);
            this.btn_changeDevNet.Name = "btn_changeDevNet";
            this.btn_changeDevNet.Size = new System.Drawing.Size(193, 29);
            this.btn_changeDevNet.TabIndex = 5;
            this.btn_changeDevNet.Text = "修改参数";
            this.btn_changeDevNet.UseVisualStyleBackColor = false;
            this.btn_changeDevNet.Click += new System.EventHandler(this.btn_changeDevNet_Click);
            // 
            // btn_openFromWeb
            // 
            this.btn_openFromWeb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openFromWeb.Location = new System.Drawing.Point(742, 329);
            this.btn_openFromWeb.Name = "btn_openFromWeb";
            this.btn_openFromWeb.Size = new System.Drawing.Size(193, 23);
            this.btn_openFromWeb.TabIndex = 6;
            this.btn_openFromWeb.Text = "Web访问";
            this.btn_openFromWeb.UseVisualStyleBackColor = true;
            this.btn_openFromWeb.Click += new System.EventHandler(this.btn_openFromWeb_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_referencePC);
            this.groupBox2.Controls.Add(this.txt_NetCardDNS);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_NetCardGateway);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txt_netCardMask);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txt_NetCardIPV4);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comb_netCard);
            this.groupBox2.Location = new System.Drawing.Point(728, 358);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 212);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计算机网络";
            // 
            // btn_referencePC
            // 
            this.btn_referencePC.Location = new System.Drawing.Point(93, 183);
            this.btn_referencePC.Name = "btn_referencePC";
            this.btn_referencePC.Size = new System.Drawing.Size(114, 23);
            this.btn_referencePC.TabIndex = 23;
            this.btn_referencePC.Text = "与电脑同网段";
            this.btn_referencePC.UseVisualStyleBackColor = true;
            this.btn_referencePC.Click += new System.EventHandler(this.btn_referencePC_Click);
            // 
            // txt_NetCardDNS
            // 
            this.txt_NetCardDNS.Location = new System.Drawing.Point(93, 154);
            this.txt_NetCardDNS.Name = "txt_NetCardDNS";
            this.txt_NetCardDNS.Size = new System.Drawing.Size(114, 21);
            this.txt_NetCardDNS.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "DNS：";
            // 
            // txt_NetCardGateway
            // 
            this.txt_NetCardGateway.Location = new System.Drawing.Point(93, 118);
            this.txt_NetCardGateway.Name = "txt_NetCardGateway";
            this.txt_NetCardGateway.Size = new System.Drawing.Size(114, 21);
            this.txt_NetCardGateway.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "网关：";
            // 
            // txt_netCardMask
            // 
            this.txt_netCardMask.Location = new System.Drawing.Point(93, 83);
            this.txt_netCardMask.Name = "txt_netCardMask";
            this.txt_netCardMask.Size = new System.Drawing.Size(114, 21);
            this.txt_netCardMask.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "子网掩码：";
            // 
            // txt_NetCardIPV4
            // 
            this.txt_NetCardIPV4.Location = new System.Drawing.Point(93, 51);
            this.txt_NetCardIPV4.Name = "txt_NetCardIPV4";
            this.txt_NetCardIPV4.Size = new System.Drawing.Size(114, 21);
            this.txt_NetCardIPV4.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 15;
            this.label14.Text = "IP地址：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "网卡：";
            // 
            // comb_netCard
            // 
            this.comb_netCard.FormattingEnabled = true;
            this.comb_netCard.Location = new System.Drawing.Point(65, 18);
            this.comb_netCard.Name = "comb_netCard";
            this.comb_netCard.Size = new System.Drawing.Size(142, 20);
            this.comb_netCard.TabIndex = 0;
            this.comb_netCard.SelectedIndexChanged += new System.EventHandler(this.comb_netCard_SelectedIndexChanged);
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(SearchDev.MainForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 582);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_openFromWeb);
            this.Controls.Add(this.btn_changeDevNet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dGrid_devList);
            this.Controls.Add(this.btn_SearchDev);
            this.Controls.Add(this.lab_devCount);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备搜索配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_devList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_devCount;
        private System.Windows.Forms.Button btn_SearchDev;
        private System.Windows.Forms.DataGridView dGrid_devList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_devDNS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_devGatway;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_devMask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_devIPV4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_devAliasName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_isDevDHCP;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_changeDevNet;
        private System.Windows.Forms.Button btn_openFromWeb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_NetCardDNS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_NetCardGateway;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_netCardMask;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_NetCardIPV4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comb_netCard;
        private System.Windows.Forms.Button btn_referencePC;
        private System.Windows.Forms.DataGridViewTextBoxColumn AliasName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn HardwareVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoftwareVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPV4;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
    }
}
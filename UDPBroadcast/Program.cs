using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SearchDev
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                MainForm formMain = new MainForm();

                Application.Run(formMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

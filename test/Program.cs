using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBox.Show("test");
            //string exeName = @"D:\Debug\WORKAHOLISM.exe";
            string exeName = @"D:\WORKAHOLISM\WORKAHOLISM\bin\Debug\WORKAHOLISM.exe";
            string args = "";
            ProcessStartInfo startInfo = new ProcessStartInfo(exeName, args)
            {
                Verb = "Runas",
                UseShellExecute = false
            };
            Process process = Process.Start(startInfo);
            process.WaitForExit();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

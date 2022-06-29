using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WORKAHOLISM
{
    class FileIO
    {
        public string[] lines;
        public string Lastline;

        private const string path = @"C:\Windows\System32\drivers\etc\hosts";
        private const string path_tmp = @"C:\Windows\System32\drivers\etc\hosts_tmp";
        private const string path_bak = @"C:\Windows\System32\drivers\etc\hosts_bak";
        //private const string path = @"E:\hosts";
        //private const string path_tmp = @"E:\hosts_tmp";
        //private const string path_bak = @"E:\hosts_bak";
        private static readonly string[] add_text = { Environment.NewLine, "127.0.0.1       www.youtube.com" };

        public FileIO()
        {
            //Encoding enc = Encoding.GetEncoding("Shift_JIS");
            //StreamWriter writer = new StreamWriter(@"E:\hosts", false, enc);
            lines = System.IO.File.ReadAllLines(path);
        }

        public string Read()
        {
            lines = System.IO.File.ReadAllLines(path);
            Lastline = lines[lines.Length - 1];

            if (Lastline[0] != '#' &&
                Lastline.Contains("127.0.0.1") && Lastline.Contains("www"))
            {
                return "block_mode";
            }
            else
            {
                return "unblock_mode";
            }
        }

        // hostファイルに禁止URLを書き込み
        public void Write()
        {
            if (!System.IO.File.Exists(path_tmp))
            {
                File.Copy(path, path_tmp, true);
            }
            File.AppendAllLines(path_tmp, add_text);
            File.Replace(path_tmp, path, path_bak, true);
        }

        // hostファイルを元に戻す
        public void Delete()
        {
                File.Replace(path_bak, path, path_bak);
        }
    }
}
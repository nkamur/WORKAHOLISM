using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

static class Program
{
    /// <summary>
    /// アプリケーションのメイン エントリ ポイントです。
    /// </summary>
    [STAThread]
    static void Main()
    {
        ResidentTest rm = new ResidentTest();
        Application.Run();
    }
}

class ResidentTest :Form
{
    private Thread thread; 

    public ResidentTest()
    {
        this.ShowInTaskbar = false;
        this.setComponents();

        thread = new Thread(intervalCheck); // ←右辺はnew Thread (new ThreadStart(intervalCheck))と等価. 暗黙的型変換によってThreadStartデリゲートに変換
        thread.Start();
    }

    private void Close_Click(object sender, EventArgs e)
    {
        thread.Abort();  
        Application.Exit();
    }

    private void intervalCheck()
    {
        while (true)
        {
            System.Threading.Thread.Sleep(10000);
            MessageBox.Show("Test");
        }
    }

    private void setComponents()
    {
        NotifyIcon icon = new NotifyIcon();
        icon.Icon = new Icon("app.ico");
        icon.Visible = true;
        icon.Text = "常駐アプリテスト";
        ContextMenuStrip menu = new ContextMenuStrip();
        ToolStripMenuItem menuItem = new ToolStripMenuItem();
        menuItem.Text = "&終了";
        menuItem.Click += new EventHandler(Close_Click);
        menu.Items.Add(menuItem);

        icon.ContextMenuStrip = menu;
    }
}
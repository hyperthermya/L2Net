using System;
using System.Windows.Forms;

namespace L2_login
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += (sender, e) => ErrorLog.Log("Unhandled UI thread exception", e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => ErrorLog.Log("Unhandled exception", e.ExceptionObject as Exception ?? new Exception(e.ExceptionObject?.ToString() ?? "unknown"));

            Application.Run(new L2NET(args));
        }
    }
}

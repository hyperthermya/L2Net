using System;
using System.IO;

namespace L2_login
{
    public static class ErrorLog
    {
        private static readonly object _lock = new object();

        public static void Log(string context, Exception e)
        {
            try
            {
                lock (_lock)
                {
                    string path = Path.Combine(Globals.PATH, "error.log");
                    string entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {context}{Environment.NewLine}{e}{Environment.NewLine}{Environment.NewLine}";
                    File.AppendAllText(path, entry);
                }
            }
            catch
            {
                // Logging must never crash the app.
            }
        }
    }
}

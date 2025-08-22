using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HVTT.UI.Window.Forms.Logging
{
    /// <summary>
    /// Ghi log vào th? m?c: Errors\\[yyyy]\\[MM]\\dd_MM_yyyy.txt
    /// M?i dòng: {dd/MM/yyyy HH:mm:ss.ffff UserId message}
    /// </summary>
    public static class HVTTFileLogger
    {
        private static readonly object _lockObj = new object();

        /// <summary>
        /// Ghi m?t dòng log.
        /// </summary>
        /// <param name="userId">Mã ng??i dùng (có th? null/empty).</param>
        /// <param name="message">N?i dung c?n ghi.</param>
        public static void Log(string userId, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            try
            {
                DateTime now = DateTime.Now;
                string basePath = GetBasePath();
                string yearFolder = Path.Combine(basePath, "Errors", now.ToString("yyyy"));
                string monthFolder = Path.Combine(yearFolder, now.ToString("MM"));
                Directory.CreateDirectory(monthFolder);

                string fileName = now.ToString("dd_MM_yyyy") + ".txt"; // dd_MM_yyyy.txt
                string fullPath = Path.Combine(monthFolder, fileName);

                string line = $"{{{now:dd/MM/yyyy HH:mm:ss.ffff} {userId ?? string.Empty} {message}}}";

                // ??m b?o thread-safe
                lock (_lockObj)
                {
                    File.AppendAllText(fullPath, line + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch
            {
                // Không throw ra ngoài ?? tránh ?nh h??ng lu?ng chính.
            }
        }

        /// <summary>
        /// Ghi log kèm Exception chi ti?t.
        /// </summary>
        public static void LogException(string userId, string message, Exception ex)
        {
            if (ex == null)
            {
                Log(userId, message);
                return;
            }
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(" | EX: ").Append(ex.GetType().FullName)
              .Append(" | MSG: ").Append(ex.Message)
              .Append(" | STACK: ").Append(ex.StackTrace);
            if (ex.InnerException != null)
            {
                sb.Append(" | INNER: ").Append(ex.InnerException.GetType().FullName)
                  .Append(" - ").Append(ex.InnerException.Message);
            }
            Log(userId, sb.ToString());
        }

        private static string GetBasePath()
        {
            try
            {
                return Application.StartupPath;
            }
            catch
            {
                return AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory;
            }
        }
    }
}

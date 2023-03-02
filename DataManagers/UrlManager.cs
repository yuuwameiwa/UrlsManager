using System.Diagnostics;

namespace UrlsManager.DataManagers
{
    public class UrlManager : IDBManager
    {
        public static void Save(string filePath, string userInput)
        {
            File.AppendAllLines(filePath, new string[] { userInput });
        }

        public static string[] Read(string filePath)
        {
            string[] urls = File.ReadAllLines(filePath);

            return urls;
        }

        public static void OpenUrl(string userUrl)
        {
            Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = userUrl
            }).Dispose();
        }

        public static string SearchUrl(string[] urls)
        {
            Console.Write("Enter URL:");

            return "a";
        }
    }
}

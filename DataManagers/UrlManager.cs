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

        // Получить ввод пользователя
        public static string AcceptUrlInput()
        {
            Console.Clear();
            Console.Write("Enter URL:");
            string? inputString = Console.ReadLine();

            return inputString == null ? null : inputString;
        }

        // Проверка строки на наличие https:// или http://
        public static string StandardizeUrlInput(string urlInput)
        {
            if (!urlInput.StartsWith("https://") && !urlInput.StartsWith("http://"))
                urlInput = $"https://{urlInput}";

            urlInput = urlInput.ToLower();

            return urlInput;
        }
    }
}

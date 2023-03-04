using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace UrlsManager.DataManagers
{
    public class UrlManager : IDBManager
    {
        /// <summary>
        /// Метод сохраняет строку в файл по пути
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="userInput">Введенная строка пользователя</param>
        public static void Save(string filePath, string userInput)
        {
            File.AppendAllLines(filePath, new string[] { userInput });
        }

        /// <summary>
        /// Прочитать все строки с файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        public static string[] Read(string filePath)
        {
            string[] urls = File.ReadAllLines(filePath);

            return urls;
        }

        /// <summary>
        /// Открыть URL в дефолт браузере
        /// </summary>
        /// <param name="userUrl"></param>
        public static void OpenUrl(string userUrl)
        {
            Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = userUrl
            }).Dispose();
        }

        /// <summary>
        /// Получить ввод пользователя
        /// </summary>
        /// <returns></returns>
        public static string AcceptUrlInput()
        {
            Console.Clear();
            Console.Write("Enter URL:");

            string? inputString = Console.ReadLine();

            return inputString == null ? null : inputString;
        }

        /// <summary>
        /// Добавить в строку https://. Проверить строку.
        /// </summary>
        /// <param name="urlInput"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string StandardizeUrlInput(string urlInput)
        {
            if (!urlInput.StartsWith("https://") && !urlInput.StartsWith("http://"))
                urlInput = $"https://{urlInput}";

            if (Uri.IsWellFormedUriString(urlInput, UriKind.Absolute))
                return urlInput;
            else
                throw new ArgumentException("Invalid Url");
        }

        /// <summary>
        /// Проверка ссылки на Ютуб
        /// </summary>
        /// <param name="youtubeUrlInput"></param>
        /// <returns></returns>
        public static bool IsYoutubeUrl(string youtubeUrlInput)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(youtubeUrlInput);

            request.Method = "HEAD";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) 
            {
                bool isYoutubeUrl = response.ResponseUri.ToString().Contains("youtube.com") ? true : false;

                return isYoutubeUrl;
            }
        }
    }
}

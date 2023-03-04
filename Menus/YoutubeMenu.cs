using UrlsManager.DataManagers;
using UrlsManager.Managers;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace UrlsManager.Menus
{
    public class YoutubeSearchMenu : Menu
    {
        public YoutubeSearchMenu(Menu parent)
        {
            Description = "Youtube Search Menu";
        }

        public override async void Action()
        {
            // Принять ввод URL пользователя 
            string urlInput = UrlManager.AcceptUrlInput();

            // IsYoutubeUrl проверяет валидность введеного URL
            if (UrlManager.IsYoutubeUrl(urlInput))
            {
                Console.WriteLine("Downloading, please wait...");

                // Получить путь куда скачивать аудио
                string savePath = ApplicationManager.GetPath("Audios");

                // Скачать аудио
                YoutubeAudioManager.DownloadVideo(urlInput, savePath).Wait();
            }
            else
            {
                throw new ArgumentException("Not Youtube URL");
            }

            // Вернуться назад
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Parent.Action();
        }
    }
}

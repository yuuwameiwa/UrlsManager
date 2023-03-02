using UrlsManager.Managers;
using UrlsManager.DataManagers;

namespace UrlsManager.Menus
{
    public class SearchUrlMenu : Menu
    {
        public SearchUrlMenu(Menu parent)
        {
            Description = "Search Url";
        }

        public override void Action()
        {
            MenuManager menuManager = new MenuManager();

            // Получить путь файла для сохранения URL
            string readPath = ApplicationManager.GetPath("SavedUrls");

            // Получить массив URL по полученному пути
            string[] urls = UrlManager.Read(readPath);

            
            int userInput = menuManager.HandleMenu(urls);

            // Получить выбранный пользователем URL 
            string userUrl = urls.GetValue(userInput).ToString();

            // Открыть URL
            UrlManager.OpenUrl(userUrl);
        }
    }
}

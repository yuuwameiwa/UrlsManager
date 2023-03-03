using UrlsManager.Managers;
using UrlsManager.DataManagers;

namespace UrlsManager.Menus
{
    public class SearchUrlMenu : Menu
    {
        public SearchUrlMenu(Menu parent)
        {
            Description = "Search Url";

            Parent = parent;

            OptionChoice = 0;
        }

        public override void Action()
        {
            // Получить путь файла для сохранения URL
            string readPath = ApplicationManager.GetPath("SavedUrls");

            // Получить массив URL по полученному пути
            string[] urls = UrlManager.Read(readPath);

            MenuManager menuManager = new MenuManager(urls);

            // Получить выбранный пользователем URL 
            while (menuManager.OptionSelected == false)
            {
                // Распечатать названия меню
                menuManager.PrintOutputs();

                ConsoleKey key = Console.ReadKey(true).Key;

                // Получить выбор меню от пользователя
                OptionChoice = menuManager.HandleInput(key);
            }

            // Получить строку выбранной
            string searchedUrl = urls.GetValue(OptionChoice).ToString();

            // Открыть URL
            UrlManager.OpenUrl(searchedUrl);
        }
    }
}

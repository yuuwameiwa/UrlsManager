using UrlsManager.DataManagers;
using UrlsManager.Managers;

namespace UrlsManager.Menus
{
    public class AddUrlMenu : Menu
    {
        public AddUrlMenu(Menu parent)
        {
            Description = "Add Url";

            Parent = parent;
        }

        public override void Action()
        {
            // Принять ввод URL пользователя
            string urlInput = UrlManager.AcceptUrlInput();

            // Проверить URL и стандартизировать
            urlInput = UrlManager.StandardizeUrlInput(urlInput);

            // Получить путь сохранения URL
            string savePath = ApplicationManager.GetPath("SavedUrls");

            // Сохранить URL в текстовой файл
            UrlManager.Save(savePath, urlInput);

            // Назад
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Parent.Action();
        }
    }
}

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
            MenuManager menuManager = new MenuManager();

            string urlInput = menuManager.AcceptInput();
            urlInput = menuManager.StandardizeInput(urlInput);

            string savePath = ApplicationManager.GetPath("SavedUrls");

            UrlManager.Save(savePath, urlInput);

            Console.WriteLine("Press any Key to Continue");
            Console.ReadKey();
            GoBack(Parent);
        }
    }
}

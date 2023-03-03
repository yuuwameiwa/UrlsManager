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
            string urlInput = UrlManager.AcceptUrlInput();

            urlInput = UrlManager.StandardizeUrlInput(urlInput);

            string savePath = ApplicationManager.GetPath("SavedUrls");

            UrlManager.Save(savePath, urlInput);

            Console.ReadKey();
            GoBack(Parent);
        }
    }
}

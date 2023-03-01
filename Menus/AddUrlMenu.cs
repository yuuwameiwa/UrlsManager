using UrlsManager.Managers;

namespace UrlsManager.Menus
{
    public class AddUrlMenu : Menu
    {
        public AddUrlMenu(Menu parent)
        {
            Description = "Add Url";
        }

        public override void Action()
        {
            MenuManager menuManager = new MenuManager();

            string urlInput = menuManager.AcceptInput();

            urlInput = menuManager.StandardizeInput(urlInput);

            Console.WriteLine(urlInput);
        }
    }
}

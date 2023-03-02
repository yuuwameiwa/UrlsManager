namespace UrlsManager.Menus
{
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            Description = "Main menu";

            ChildrenArray = new Menu[]
            {
                new AddUrlMenu(this),
                new SearchUrlMenu(this),
                new YoutubeSearchMenu(this)
            };
        }
    }
}

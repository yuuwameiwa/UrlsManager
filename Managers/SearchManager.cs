namespace UrlsManager.Managers
{
    public class SearchManager
    {
        public static string SearchQuery { get; private set; }

        public static string Search(ConsoleKey key)
        {
            Console.WriteLine($"S: {SearchQuery}");
            if ((key >= ConsoleKey.A && key <= ConsoleKey.Z) ||
                (key >= ConsoleKey.Oem1 && key <= ConsoleKey.OemPeriod))
            {
                SearchQuery += key;
            }

            return SearchQuery;
        }
    }
}

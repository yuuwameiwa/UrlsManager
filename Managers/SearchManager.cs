namespace UrlsManager.Managers
{
    public class SearchManager
    {
        private static bool IsSearchSubmitted { get; set; } = false;
        private static string SearchQuery { get; set; }

        public static string Search()
        {
            while (IsSearchSubmitted == false)
            {
                Console.Clear();

                Console.Write($"Поиск: {SearchQuery}");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (char.IsLetterOrDigit(keyInfo.KeyChar) || char.IsPunctuation(keyInfo.KeyChar))
                {
                    SearchQuery += keyInfo.KeyChar;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && SearchQuery.Length > 0)
                {
                    SearchQuery = SearchQuery.Remove(SearchQuery.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    IsSearchSubmitted = true;
                }
            }

            return SearchQuery;
        }
    }
}

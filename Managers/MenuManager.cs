using System;
using System.Buffers;
using UrlsManager.Menus;

namespace UrlsManager.Managers
{
    /// <summary>
    /// Класс отвечает за:
    /// - Любой вывод чего-либо на экран 
    /// - Выбор пользователя какой-либо опции
    /// - Получение ввода пользователя с консоли
    /// </summary>
    public class MenuManager
    {
        public int HandleMenu( string[] outputs )
        {
            int currentSelection = 0;
            string searchQuery = "";

            // Распечатать строки
            PrintOutputs(outputs, currentSelection);

            // Получать ввод пользователя
            bool optionSelected = false;
            while (!optionSelected) 
            {
                ConsoleKeyInfo key = Console.ReadKey();

                // Отвечать за нажатия стрелок пользователя
                if (key.Key == ConsoleKey.UpArrow && currentSelection > 0) 
                {
                    currentSelection--;
                    // PrintOutputs(outputs, currentSelection, searchQuery);
                }
                else if (key.Key == ConsoleKey.DownArrow && currentSelection < outputs.Length - 1)
                {
                    currentSelection++;
                    // PrintOutputs(outputs, currentSelection, searchQuery);
                }
                // Ответ в случае нажатия Enter
                else if (key.Key == ConsoleKey.Enter) 
                {
                    optionSelected = true;
                }
                // Поиск
                else if(char.IsLetterOrDigit(key.KeyChar) || char.IsPunctuation(key.KeyChar) || key.Key == ConsoleKey.Backspace)
                {
                    if (char.IsLetterOrDigit(key.KeyChar) || char.IsPunctuation(key.KeyChar))
                    {
                        searchQuery += key.KeyChar;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (searchQuery.Length > 0)
                        {
                            searchQuery = searchQuery.Remove(searchQuery.Length - 1);
                        }
                    }                 
                }

                string[] searchOutputs = Array.FindAll(outputs, url => url.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0);
                PrintOutputs(searchOutputs, currentSelection, searchQuery);
            }

            // Вернуть индекс выбранного output
            return currentSelection;
        }

        public static void PrintOutputs(string[] outputs, int currentSelection, string searchQuery = "")
        {
            Console.Clear();

            Console.WriteLine($"Search for \"{searchQuery}\"\n");

            // Распечатать строки. Выбранная строка подсвечивается красным
            foreach ((string output, int index) in outputs.Select((value, index) => (value, index)))
            {
                // Покрас выбора в красный
                if (index == currentSelection)      
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{index + 1}. {output}\r");

                Console.ResetColor();
            }
        }

        // Получить ввод пользователя
        public string AcceptUrlInput()
        {
            Console.Clear();
            Console.Write("Enter URL:");
            string? inputString = Console.ReadLine();

            return inputString == null ? null : inputString;
        }

        // Проверка строки на наличие https:// или http://
        public string StandardizeUrlInput(string urlInput)
        {
            if (!urlInput.StartsWith("https://") && !urlInput.StartsWith("http://"))
                urlInput = $"https://{urlInput}";

            urlInput = urlInput.ToLower();

            return urlInput;
        }
    }
}

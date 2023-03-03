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
        private string[] Outputs;
        
        private int SelectedIdx;
        public bool OptionSelected { get; protected set; }
        
        public MenuManager(string[] outputs)
        {
            Outputs = outputs;
            SelectedIdx = 0;
            OptionSelected = false;
        }

        public void PrintOutputs(string searchQuery)
        {
            Console.CursorVisible = false;
            // Очистить меню.
            for (int i = 0; i < Console.WindowHeight; i++)
                for (int j = 0; j < Console.WindowWidth; j++)
                    Console.Write(' ');
            Console.CursorVisible = true;

            string[] filteredOutputs = Outputs.Where(output => output.Contains(searchQuery)).ToArray();

            foreach ((string output, int index) in filteredOutputs.Select((value, index) => (value, index)))
            {
                Console.SetCursorPosition(0, index);

                if (index == SelectedIdx)
                    Console.WriteLine("> " + output.PadRight(50));
                else
                    Console.WriteLine(" " + output.PadRight(50));
            }
        }

        public void PrintOutputs()
        {
            PrintOutputs("");
        }

        public int HandleInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (SelectedIdx > 0)
                        SelectedIdx--;
                    break;
                case ConsoleKey.DownArrow:
                    if (SelectedIdx < Outputs.Length - 1)
                        SelectedIdx++;
                    break;
                case ConsoleKey.Enter:
                    OptionSelected = true;
                    return SelectedIdx;
            }

            return SelectedIdx;
        }
    }
}

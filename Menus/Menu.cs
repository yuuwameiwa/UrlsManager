using System.ComponentModel;
using UrlsManager.Managers;

namespace UrlsManager.Menus
{
    public abstract class Menu
    {
        public string Description { get; private protected set; }

        protected Menu[] ChildrenArray;

        public Menu Parent { get; set; }

        public Menu () { }

        public Menu(Menu parent)
        {
            Parent = parent;
        }

        public virtual void Action()
        {
            MenuManager menuManager = new MenuManager();

            // Записать в массив названия меню
            string[] names = ChildrenArray.Select(child  => child.Description).ToArray();

            // Распечатать их и получить выбор пользователя
            int userInput = menuManager.HandleMenu(names);

            // Вызвать Action() у выбранной опции
            ChildrenArray[userInput].Action();
        }

        public void GoBack()
        {
            Console.Clear();
            Parent.Action();
        }
    }
}

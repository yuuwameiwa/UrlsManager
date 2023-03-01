using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlsManager.DataManagers
{
    public class UrlManager : IDBManager
    {
        public static void Save(string filePath, string userInput)
        {
            File.AppendAllLines(filePath, new string[] { userInput });
        }
    }
}

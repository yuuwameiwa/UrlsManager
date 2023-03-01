using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UrlsManager.Managers
{
    public class ApplicationManager
    {
        public static string GetPath(string option)
        {
            string programPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string rootPath = programPath.Substring(0, programPath.IndexOf(@"\bin\"));

            string[] settings = File.ReadAllLines($"{rootPath}" + @"\application.txt");

            string desiredDirectory = "";

            foreach (string setting in settings)
                if (setting.StartsWith(option)) 
                    desiredDirectory = setting;

            desiredDirectory = desiredDirectory.Substring(desiredDirectory.LastIndexOf('@') + 2);

            return desiredDirectory;
        }
    }
}

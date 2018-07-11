using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace InTask
{
    public class FileChecker
    {        
        /// <summary>
        /// Проверяет доступность файла.        
        /// </summary>
        /// <param name="file">Принимает путь к файлу с именем.</param>
        /// <returns>Возвращает истину если файл существует.</returns>
        public bool CheckExists(string file)
        {
            if (!File.Exists(file))
            {                
                return false;               
            }

            return true;
        }

        /// <summary>
        /// Проверяет размер файла.
        /// </summary>
        /// <param name="file">Принимает путь к файлу с именем.</param>
        /// <returns>Возвращает истину если размер файла не превышает 2мб.</returns>
        public bool CheckSize(string file)
        {
            FileInfo fileInfo = new FileInfo(file);

            if(fileInfo.Length > 2097152)
            {
                return false;
            }

            return true;
        }

    }
}

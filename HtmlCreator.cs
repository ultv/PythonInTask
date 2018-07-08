using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InTask
{
    class HtmlCreator
    {
        static string HTML_HEADER = "<!DOCTUPE html><html><head><title>Тестовое задание C#. Выполнил: Седов.А.П.</title></head><body><br>----НАЧАЛО ВЫВОДА----<p>";
        static string HTML_FOOTER = "</p><p>----КОНЕЦ ВЫВОДА----</p></body></html>";

        /// <summary>
        /// Создает "шапку" html файла.
        /// </summary>
        /// <param name="writer"></param>
        public void CreateHeader(StreamWriter writer)
        {
            writer.WriteLine(HTML_HEADER);
        }

        /// <summary>
        /// Создает "тело" html файла.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="str"></param>
        public void CreateBody(StreamWriter writer, string str)
        {
            writer.WriteLine(str);
        }

        /// <summary>
        /// Создаёт "подвал" html файла.
        /// </summary>
        /// <param name="writer"></param>
        public void CreateFoother(StreamWriter writer)
        {
            writer.WriteLine(HTML_FOOTER);
        }

    }






   
}

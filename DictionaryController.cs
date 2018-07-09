using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InTask
{
    class DictionaryController
    {        
        public List<string> Dict { get; set; }
        public string[] StrSplit { get; set; }
        public string Compare { get; set; }
        public string Start = "----НАЧАЛО ФАЙЛА----";
        public string End = "----КОНЕЦ ФАЙЛА----";
        public readonly string fileDictionary = Directory.GetCurrentDirectory() + "\\file_dictionary.txt";

        public DictionaryController()
        {          
            Dict = new List<string>();
        }

        /// <summary>
        /// Загружает словарь в коллекцию типа List.
        /// </summary>
        public void LoadDictionary()
        {

            using (StreamReader reader = new StreamReader(fileDictionary, Encoding.GetEncoding(1251)))
            {
                do
                {
                    string line = reader.ReadLine();
                    if (line != Start)
                    Dict.Add(line);

                } while (!reader.EndOfStream);
            }     
        }

        /// <summary>
        /// Разделяет строку на слова.
        /// Сравнивает каждое слово со словами в словаре.
        /// Форматирует строу с учётом результатов сравнения.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Возвращает форматированную строку.</returns>
        public string CompareDictionary(string str)
        {

            Compare = "";

            if ((str != Start) && (str != End) && (!String.IsNullOrEmpty(str)))
            {                

                StrSplit = str.Split(' ');

                foreach (string word in StrSplit)
                {

                    if (Dict.Contains(word))
                        Compare = Compare + " <b><i>" + word + "</b></i> ";
                    else
                        Compare = Compare + word + " ";
                }
            }
                        
            return Compare;
        }
    }
}

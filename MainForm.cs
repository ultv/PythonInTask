using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace InTask
{
    public partial class MainForm : Form
    {

        public readonly string fileText = Directory.GetCurrentDirectory() + "\\file_text.txt";
        public readonly string fileDictionary = Directory.GetCurrentDirectory() + "\\file_dictionary.txt";
        public readonly string fileHtml = Directory.GetCurrentDirectory() + "\\file_result.html";

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка "Выполнить".
        /// Производит проверку файла словаря и файла с текстом на наличие и соответствие максимально допустимому размеру.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRun_Click(object sender, EventArgs e)
        {

            FileChecker fileChecker = new FileChecker();            

            if (!fileChecker.CheckExists(fileText))
            {
                MessageBox.Show($"Файл {fileText} не найден.");
            }
            else if (!fileChecker.CheckExists(fileDictionary))
            {
                MessageBox.Show($"Файл {fileDictionary} не найден.");
            }
            else if (!fileChecker.CheckSize(fileText))
            {
                MessageBox.Show($"Параметры файла {fileText} не соответствует максимально допустимому размеру.");
            }
            else if (!fileChecker.CheckSize(fileDictionary))
            {
                MessageBox.Show($"Параметры файла {fileDictionary} не соответствует максимально допустимому размеру.");
            }
            else
            {
                HtmlCreator html = new HtmlCreator();
                DictionaryController dict = new DictionaryController();

                dict.LoadDictionary();

                using (StreamWriter writer = new StreamWriter(fileHtml))
                {

                    html.CreateHeader(writer);

                    using (StreamReader reader = new StreamReader(fileText, Encoding.GetEncoding(1251)))
                    {
                        while (!reader.EndOfStream)
                        {

                            string strIn = reader.ReadLine();
                            if((strIn != dict.Start) && (strIn != dict.End))
                            {
                                string strOut = dict.CompareDictionary(strIn);
                                writer.WriteLine(strOut + "<br>");
                                strOut = "";
                            }

                            strIn = "";                                                        
                        }
                    }
                        
                    html.CreateFoother(writer);
                }

                Process.Start(fileHtml);
            }            
        }
    }
}

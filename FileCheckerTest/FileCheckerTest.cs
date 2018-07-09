using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InTask;
using System.IO;

namespace FileCheckerTest
{
    [TestClass]
    public class FileCheckerTest
    {
        [TestMethod]
        public void CheckExist_empty_string_false_returned()
        {
            //Arrange            
            FileChecker fileChecker = new FileChecker();
            string accept = "";
            bool expected = false;

            //Act
            bool actual = fileChecker.CheckExists(accept);

            //Result
            Assert.AreEqual(expected, actual);
        }
       

        [TestMethod]
        public void CheckSize_file_big_max_size_false_returned()
        {
            //Arrange            
            FileChecker fileChecker = new FileChecker();

            string accept = Directory.GetCurrentDirectory() + "file-test-max-size";
            using (FileStream fstream = new FileStream(accept, FileMode.Create))
            {

                byte[] array = new byte[2097153];

                for (int i = 0; i < 2097153; i++)
                {
                    array[i] = 0;
                }
                
                fstream.Write(array, 0, array.Length);
               
            }
            
            bool expected = false;

            //Act
            bool actual = fileChecker.CheckSize(accept);

            //Result
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckSize_file_no_big_max_size_true_returned()
        {
            //Arrange            
            FileChecker fileChecker = new FileChecker();

            string accept = Directory.GetCurrentDirectory() + "file-test-no-max-size";
            using (FileStream fstream = new FileStream(accept, FileMode.Create))
            {

                byte[] array = new byte[2097152];

                for (int i = 0; i < 2097152; i++)
                {
                    array[i] = 0;
                }

                fstream.Write(array, 0, array.Length);

            }

            bool expected = true;

            //Act
            bool actual = fileChecker.CheckSize(accept);

            //Result
            Assert.AreEqual(expected, actual);
        }

    }
}

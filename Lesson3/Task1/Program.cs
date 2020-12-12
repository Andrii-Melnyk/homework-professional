using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {           
            var file = new FileInfo(@".\Test.txt");
            StreamWriter sw = file.CreateText();
            sw.WriteLine("Hello world!");
            sw.WriteLine("Hello Kyiv!");
            sw.Close();

            StreamReader sr = file.OpenText();
            string lineFromFile = null;
            while ((lineFromFile = sr.ReadLine()) != null)
            {
                Console.WriteLine(lineFromFile);
            }
        }
    }
}

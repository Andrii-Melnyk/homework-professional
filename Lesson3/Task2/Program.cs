using System;
using System.IO;
//Дополнительное задание:
//Создать набор классов - декораторов для работы со стримами. За основу можете взять StreamWriter
//Примеры декораторов:
//RepeatWriter
//UpperCaseWriter
//LowerCaseWritter
//EncryptWritter // для побитового шифрования, пример можно взять в примерах с С# Starter 

//Пример использования:
//var writer = file.OpenText();
//writer = new RepeatWriter(writer, 2);
//writer = new UpperCaseWriter(writer);
//writer = new EncryptWriter(writer, key: 73);
//writer.WriteLine("Hello World!");

namespace Task2
{
    class RepeatWriter: StreamWriter
    {      
        

        public RepeatWriter(string path, int repeat):base(path)
        {
            StreamReader sr = new StreamReader(path);
            string lineFromFile = null;
            while ((lineFromFile = sr.ReadLine()) != null)
            {
                Console.WriteLine(lineFromFile);
            }
            for (int i = 0; i <= repeat ; i++)
            {
                base.Write(sr.ReadLine());               
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileInfo(@"D:\Test.txt");
            StreamWriter sw = file.CreateText();
            sw.WriteLine("Hello world!");           
            sw = new RepeatWriter(@"D:\Test.txt", 3);

            StreamReader sr = file.OpenText();
            string lineFromFile = null;
            while ((lineFromFile = sr.ReadLine()) != null)
            {
                Console.WriteLine(lineFromFile);
            }
            sw.Close();

        }
    }
}

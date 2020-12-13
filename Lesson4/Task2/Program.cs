using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
//Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы
//заменить все предлоги на слово «ГАВ!».
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"..\..\..\Text.txt", Encoding.UTF8);
            Console.WriteLine(text);
            Console.WriteLine();           

            string newText = Regex.Replace(text, @"\s[а-я]{1,4}\s", " ГАВ! ");
            File.WriteAllText(@"..\..\..\Text1.txt", newText, Encoding.UTF8);

            Console.WriteLine(newText);
        }
    }
}

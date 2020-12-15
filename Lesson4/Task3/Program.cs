using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
//Создайте текстовый файл-чек по типу «Наименование товара – 0.00 (цена) грн.» с
//определенным количеством наименований товаров и датой совершения покупки. Выведите на
//экран информацию из чека в формате текущей локали пользователя и в формате локали en-
//US.
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = File.CreateText(@"D:\Test.txt");
            sw.WriteLine($"Груши -------------- {65.34} грн.");
            sw.WriteLine($"Сливы -------------- {50.78} грн.");
            sw.WriteLine($"Яблоки ------------- {25.20} грн.");
            sw.Close();

            string check = File.ReadAllText(@"D:\Test.txt", Encoding.Default);
            var myCulture = CultureInfo.CurrentCulture;
            var usCulture = new CultureInfo("en-US");

            string pattern = @"[0-9]+(\.|\,)[1-9]+";

            string myCultureCheck = Regex.Replace(check, pattern, (m) => Double.Parse(m.Value).ToString("C", myCulture));
            string usCultureCheck = Regex.Replace(check, pattern, (m) => Double.Parse(m.Value).ToString("C", usCulture));

            System.Console.WriteLine(myCultureCheck);
            Console.WriteLine(new string('-', 30));

            System.Console.WriteLine(usCultureCheck);

            System.Console.WriteLine();
        }
    }
}

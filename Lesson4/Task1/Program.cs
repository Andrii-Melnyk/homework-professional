using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Напишите программу, которая бы позволила вам по указанному адресу web - страницы
//выбирать все ссылки на другие страницы, номера телефонов, почтовые адреса и сохраняла
//полученный результат в файл.
namespace Task1
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            try
            {
                Console.Write("Введите адресс сайта: ");
                string url = Console.ReadLine();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                StreamWriter writer = File.CreateText(@"D:\Log.txt");


                var regex = new Regex(@"(?<link>http[s]?:\/(?:\/[^\/]+){1,}(?:\/[А-Яа-я\w ]+\.[a-z]{3,5}(?![\/])))");

                foreach (Match m in regex.Matches(responseBody))
                {
                    writer.WriteLine("Ссылка: {0}", m.Groups["link"].Value);
                }

                regex = new Regex(@"(?<phone>(\+38[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10})");

                foreach (Match m in regex.Matches(responseBody))
                {
                    writer.WriteLine("Тел. номер: {0}", m.Groups["phone"].Value);
                }

                regex = new Regex(@"(?<email>\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,3}\b)");

                foreach (Match m in regex.Matches(responseBody))
                {
                    writer.WriteLine("E-Mail: {0}", m.Groups["email"].Value);
                }

                writer.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
    }
}

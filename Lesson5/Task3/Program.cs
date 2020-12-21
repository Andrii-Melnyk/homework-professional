using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var configuration = configurationBuilder.AddJsonFile("settings.json").Build();


            var heigh = Int32.Parse(configuration["Console:Height"]);
            var wdtht = Int32.Parse(configuration["Console:Widtht"]);

            var color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), configuration["Console:Colour"]);

            Console.SetWindowSize(heigh, wdtht);
            Console.ForegroundColor = color;
            Console.WriteLine("Test");

            string json = File.ReadAllText("settings.json");

            string patern = Console.ForegroundColor.ToString();
            string result = Regex.Replace(json, patern, "Red"); //Не смог написать нормальную регулярку
            File.WriteAllText("settings.json", result);

            Console.ReadKey();
        }
    }
}

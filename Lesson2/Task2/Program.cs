using System;
using System.Collections.Generic;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>()
            {
                { 128738232, 2833.56 },
                {426738237, 1228381.97 },
                {920738217, 6221.01 }
            };

            SortedDictionary<int, double> accounts1 = new SortedDictionary<int, double>() {
                { 128738232, 2833.56 },
                {426738237, 1228381.97 },
                {920738217, 6221.01 }
            };

            SortedList<int, double> accounts2 = new SortedList<int, double>() {
                { 128738232, 2833.56 },
                {426738237, 1228381.97 },
                {920738217, 6221.01 }
            };

            foreach (var item in accounts)
            {
                Console.WriteLine($"Счет: {item.Key}  Сумма: {item.Value}");
            }
        }
    }
}

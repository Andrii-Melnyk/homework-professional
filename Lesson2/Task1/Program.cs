using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        public static List<Customer> GetCustomersByProduct(Dictionary<Customer, List<string>> customers, string product)
        {
            List<Customer> customerList = new List<Customer>();
            foreach (var item in customers)
            {
                if (item.Value.Contains(product))
                {
                    customerList.Add(item.Key);
                }
            }
            return customerList;
        }
        static void Main(string[] args)
        {
            Dictionary<Customer, List<string>> customers = new Dictionary<Customer, List<string>>();

            customers.Add(new Customer("Петр Петров"), new List<string> { "Еда", "Одежда", "Электроника" });
            customers.Add(new Customer("Татьяна Иванова"), new List<string> { "Одежда" });
            customers.Add(new Customer("Виталий Орлов"), new List<string> { "Еда", "Одежда", });
            customers.Add(new Customer("Евгений Скворцов"), new List<string> { "Электроника" });

            foreach (var item in customers)
            {
                Console.Write($"{item.Key.FullName}: ");
                foreach (var value in item.Value)
                {
                    Console.Write($"{value}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 35));

            string productСategory = "Одежда";
            var customerList = GetCustomersByProduct(customers, productСategory);

            foreach (var item in customerList)
            {
                Console.WriteLine($"{ item.FullName} - {productСategory }");
            }

            Console.ReadKey();
        }
    }
}

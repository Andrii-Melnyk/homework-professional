using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizens citizens = new Citizens();
            citizens.Add(new Student("Иван", "Иванов", "НО23245483"));
            citizens.Add(new Pensioner("Петр", "Петров", "НО10045483"));
            citizens.Add(new Pensioner("Андрей", "Петров", "НО6005483"));
            citizens.Add(new Pensioner("Александр", "Петров", "НО6005483"));
            citizens.Add(new Working("Алекс", "Иванов", "РО6805483"));

            citizens.Remove(new Pensioner("Петр", "Петров", "НО10045483"));
            foreach (Citizen item in citizens)
            {
                Console.WriteLine($"{item.Name} {item.Surname} {item.PassportID}");
            }
            Console.WriteLine(new String('-', 35));

            Citizen lastElement = citizens.ReturnLast(out int index);
            Console.WriteLine($"{index} {lastElement.Name} {lastElement.Surname} {lastElement.PassportID}");
            Console.WriteLine(new String('-', 35));

            citizens.Clear();

            Console.WriteLine($"Count {citizens.Count}");
            Console.ReadKey();
        }
    }
}

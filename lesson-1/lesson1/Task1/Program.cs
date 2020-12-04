using System;
using System.Collections;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendar calendar = new Calendar();

            foreach (var item in calendar)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new String('-', 30));

            Console.WriteLine(calendar.GetMonthByNumber(1));
            Console.WriteLine(new String('-', 30));

            var montshByDaysCount = calendar.GetMontshByDaysCount(30);
            foreach (var item in montshByDaysCount)
            {
                Console.WriteLine(item);
            }          

            Console.ReadKey();
        }
    }
}

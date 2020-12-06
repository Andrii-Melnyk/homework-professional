using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Task3
{
    class DateComparison : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            DateTime x1 = (DateTime)x;
            DateTime y1 = (DateTime)y;
            
            return x1.Year == y1.Year;
        }
        public int GetHashCode(object x)
        {
            DateTime x1 = (DateTime)x;
            return x1.Year.GetHashCode();
        }
    }
    class Program
    {       

        static void Main(string[] args)
        {
            OrderedDictionary orderedDictionary = new OrderedDictionary(new DateComparison());
            try
            {
                orderedDictionary.Add(new DateTime(2018, 03, 23), "12458568489393");
                orderedDictionary.Add(new DateTime(2019, 06, 20), "67654982289393");
                orderedDictionary.Add(new DateTime(2020, 03, 07), "16834982289393");
                orderedDictionary.Add(new DateTime(2017, 03, 07), "16834982289393");
                orderedDictionary.Add(new DateTime(2020, 06, 22), "78834980089393");                
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            foreach (DictionaryEntry item in orderedDictionary)
            {
                Console.WriteLine($"Дата создания: {item.Key}   Счет: {item.Value}");
            }
           
        }
    }
}

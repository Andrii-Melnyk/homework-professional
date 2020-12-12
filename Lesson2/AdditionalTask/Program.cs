using System;
using System.Collections;

namespace AdditionalTask
{
    class KeyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedList sortedList = new SortedList()
            {
                { "FIRST", "Hello" },
                { "SECOND", "World" },
                { "THIRD", "!" }
            };

            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"{item.Key} - {item.Value} ");
            }

            Console.WriteLine();
            SortedList sortedList1 = new SortedList(new KeyComparer())
            {
                { "FIRST", "Hello" },
                { "SECOND", "World" },
                { "THIRD", "!" }
            };

            foreach (DictionaryEntry item in sortedList1)
            {
                Console.WriteLine($"{item.Key} - {item.Value} ");
            }
        }
    }
}

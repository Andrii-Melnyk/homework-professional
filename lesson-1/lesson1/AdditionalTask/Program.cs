using System;
using System.Collections;

namespace AdditionalTask
{
    class Program
    {
        static IEnumerable GetOddNumbersSquare(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                    yield return numbers[i] * numbers[i];
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable oddNumbersSquare = GetOddNumbersSquare(array);

            foreach (var item in oddNumbersSquare)
            {
                Console.Write($"{item} ");
            }

            Console.ReadKey();
        }
    }
}

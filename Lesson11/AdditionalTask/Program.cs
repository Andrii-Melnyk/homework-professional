using System;
using System.Threading;

//Используя конструкции блокировки, создайте метод, который будет в цикле for (допустим, на 10
//итераций) увеличивать счетчик на единицу и выводить на экран счетчик и текущий поток.
//Метод запускается в трех потоках. Каждый поток должен выполниться поочередно, т.е. в
//результате на экран должны выводиться числа (значения счетчика) с 1 до 30 по порядку, а не в
//произвольном порядке.
namespace AdditionalTask
{
    class Program
    {
        //private static Object block = new object();
        private static int counter = 0;

        static void Print()
        {
            for (int i = 0; i < 10; i++)
            {
                Interlocked.Increment(ref counter);
                Console.WriteLine($"{counter} из  потока: {Thread.CurrentThread.GetHashCode()}");
            }
        }


        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(Print);
            }
            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
                threads[i].Join();
            }
        }
    }
}

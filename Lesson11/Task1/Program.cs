using System;
using System.IO;
using System.Threading;

//Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м
//файлам. Считайте из этих файлов содержимое и попытайтесь записать полученную
//информацию в третий файл. Чтение/запись должны осуществляться одновременно в каждом
//из дочерних потоков. Используйте блокировку потоков для того, чтобы добиться корректной
//записи в конечный файл.
namespace Task1
{
    class Program
    {
        static object blok = new object();
        static void ReadLog1()
        {
            string text = File.ReadAllText("Log1.txt");

            lock(blok)
            {
                File.AppendAllText("Log3.txt", text + " ");
            }
        }
        static void ReadLog2()
        {
            string text = File.ReadAllText("Log2.txt");

            lock (blok)
            {
                File.AppendAllText("Log3.txt", text);
            }
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(ReadLog1);
            thread1.Start();
            thread1.Join();
            Thread thread2 = new Thread(ReadLog2);
            thread2.Start();
            thread2.Join();
        }
    }
}

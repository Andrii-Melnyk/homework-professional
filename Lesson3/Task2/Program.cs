using System;
using System.IO;
//Дополнительное задание:
//Создать набор классов - декораторов для работы со стримами. За основу можете взять StreamWriter
//Примеры декораторов:
//RepeatWriter
//UpperCaseWriter
//LowerCaseWritter
//EncryptWritter // для побитового шифрования, пример можно взять в примерах с С# Starter 

//Пример использования:
//var writer = file.OpenText();
//writer = new RepeatWriter(writer, 2);
//writer = new UpperCaseWriter(writer);
//writer = new EncryptWriter(writer, key: 73);
//writer.WriteLine("Hello World!");

namespace Task2
{
    interface IStreamWriter
    {
        void WriteLine(string value);
    }
    class BasicWriter : IStreamWriter
    {
        private readonly StreamWriter _writer;

        public BasicWriter(StreamWriter writer)
        {
            _writer = writer;
        }

        public void WriteLine(string value)
        {
            _writer.WriteLine(value);
        }
    }

    class RepeatWriter : IStreamWriter
    {
        private readonly IStreamWriter _underlyingWriter;
        private readonly int _repeat;

        public RepeatWriter(IStreamWriter streamWriter, int repeat)
        {
            _underlyingWriter = streamWriter;
            _repeat = repeat;
        }

        public void WriteLine(string value)
        {
            for (int i = 0; i < _repeat; i++)
            {
                _underlyingWriter.WriteLine(value);
            }
        }
    }
    class UpperCaseWriter : IStreamWriter
    {
        private readonly IStreamWriter _underlyingWriter;

        public UpperCaseWriter(IStreamWriter streamWriter)
        {
            _underlyingWriter = streamWriter;
        }
        public void WriteLine(string value)
        {
            _underlyingWriter.WriteLine(value.ToUpperInvariant());
        }
    }
    class EncryptWriter : IStreamWriter
    {
        private readonly IStreamWriter _underlyingWriter;

        private int _key;
        public EncryptWriter(IStreamWriter streamWriter, int key = 73)
        {
            _underlyingWriter = streamWriter;
            _key = key;
        }
        public void WriteLine(string value)
        {
            string result = "";
            for (int i = 0; i < value.Length; i++)
            {
                result += (char)(value[i] ^ _key);
            }               
            
            _underlyingWriter.WriteLine(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(@"D:\Test.txt");
            IStreamWriter writer = new BasicWriter(sw);
            writer = new RepeatWriter(writer, 3);
            writer = new UpperCaseWriter(writer);
            writer = new EncryptWriter(writer);
            writer.WriteLine("Hello!");
            sw.Close();

            Console.ReadKey();
        }
    }
}

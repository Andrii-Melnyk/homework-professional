using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

//Создайте пользовательский тип (например, класс) и выполните сериализацию объекта этого
//типа, учитывая тот факт, что состояние объекта необходимо будет передать по сети.
namespace AdditionalTask
{
    class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("BMX X5", 240);
            var json = JsonConvert.SerializeObject(car, Formatting.Indented);

            File.WriteAllText("Car.json", json);            
        }
    }
}

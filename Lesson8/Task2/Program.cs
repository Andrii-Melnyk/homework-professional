using System;
using System.IO;
using System.Xml.Serialization;

//Создайте новое приложение, в котором выполните десериализацию объекта из предыдущего
//примера. Отобразите состояние объекта на экране.
namespace Task2
{
    public class Car
    {
        public string model;
        public int maxSpeed;
        public DateTime date;
        public Car()
        {

        }
        public Car(string model, int maxSpeed, DateTime date)
        {
            this.model = model;
            this.maxSpeed = maxSpeed;
            this.date = date;
        }
    }
    public class Truck
    {
        [XmlAttribute("CarModel")]
        public string model;

        [XmlAttribute("MaxSpeed")]
        public int maxSpeed;
        public DateTime date;
        public Truck()
        {

        }
        public Truck(string model, int maxSpeed, DateTime date)
        {
            this.model = model;
            this.maxSpeed = maxSpeed;
            this.date = date;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileStream streamCar = new FileStream("Car.xml", FileMode.Open);
            XmlSerializer serializerCar = new XmlSerializer(typeof(Car));
            var car = (Car)serializerCar.Deserialize(streamCar);
            Console.WriteLine($"Марка машины: {car.model}");
            Console.WriteLine($"Год выпуска: {car.date.Year}");

            Console.WriteLine(new String('-',30));

            FileStream streamTruck = new FileStream("Truck.xml", FileMode.Open);
            XmlSerializer serializerTruck = new XmlSerializer(typeof(Truck));
            var truck = (Truck)serializerTruck.Deserialize(streamTruck);
            Console.WriteLine($"Марка машины: {truck.model}");
            Console.WriteLine($"Год выпуска: {truck.date.Year}");
        }
    }
}

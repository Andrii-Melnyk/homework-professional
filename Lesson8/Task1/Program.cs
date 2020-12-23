using System;
using System.IO;
using System.Xml.Serialization;

//Создайте класс, поддерживающий сериализацию. Выполните сериализацию объекта этого
//класса в формате XML. Сначала используйте формат по умолчанию, а затем измените его
//таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML.
namespace Task1
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
            Car car = new Car("BMW X5", 150, new DateTime(2016, 09, 21));
            var streamCar = new FileStream("Car.xml", FileMode.Create);
            XmlSerializer serializerCar = new XmlSerializer(typeof(Car));
            serializerCar.Serialize(streamCar, car);
            streamCar.Close();

            Truck truck = new Truck("MAN TGS", 240, new DateTime(2019, 03, 23));
            var streamTruck = new FileStream("Truck.xml", FileMode.Create);
            XmlSerializer serializerTruck = new XmlSerializer(typeof(Truck));
            serializerTruck.Serialize(streamTruck, truck);
            streamTruck.Close();
        }
    }
}

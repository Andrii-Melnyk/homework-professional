using System;
using System.Reflection;
using System.IO;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFrom("Task1.dll");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Type type = assembly.GetType("Task1.CelsiusToFahrenheit");

            object instance = Activator.CreateInstance(type);
            
            object[] parameters = {  0 };
            MethodInfo method = type.GetMethod("ConvertTemperature");

            
            double temperature = (double)method.Invoke(instance, parameters);

            Console.WriteLine(temperature);
        }
    }
}

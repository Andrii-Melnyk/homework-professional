using System;
using System.Xml.XPath;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmldoc = new XPathDocument("TelephoneBook.xml");
            var navigator = xmldoc.CreateNavigator();

            var noda = navigator.SelectSingleNode("/MyContacts/Contact/@TelephoneNumber");

            Console.WriteLine($"PhoneNumber = {noda.Value}");
        }
    }
}

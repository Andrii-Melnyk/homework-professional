using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextWriter textWritter = new XmlTextWriter("TelephoneBook.xml", Encoding.Default);
            textWritter.Formatting = Formatting.Indented;
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("MyContacts");            
            textWritter.WriteEndElement();
            textWritter.Close();


            var document = new XPathDocument("TelephoneBook.xml");    //К сожалению не смог реализовать создание XML на чистом XPath

            var xmldoc = new XmlDocument();
            xmldoc.Load("TelephoneBook.xml");
            XPathNavigator navigator = xmldoc.CreateNavigator();
            
            navigator.MoveToChild("MyContacts", "");            
            navigator.AppendChild("<Contact>Andrii</Contact>");
            navigator.MoveToFirstChild();
            navigator.CreateAttribute("", "TelephoneNumber", "", "+38(067)345-23-32");

            xmldoc.Save("TelephoneBook.xml");
        }
    }
}

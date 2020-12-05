using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    abstract class Citizen
    {
        public string Name { get;}
        public string Surname { get;}
        public string PassportID { get;}
        public Citizen(string name, string surname, string passportID)
        {
            Name = name;
            Surname = surname;
            PassportID = passportID;
        }

        public override bool Equals(object obj)
        {
            return obj is Citizen citizen &&
                   PassportID == citizen.PassportID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PassportID);
        }
    }
    class Student : Citizen
    {
        public Student(string name, string surname, string passportID):base(name, surname, passportID)
        {

        }
    }
    class Pensioner : Citizen
    {
        public Pensioner(string name, string surname, string passportID) : base(name, surname, passportID)
        {

        }
    }
    class Working : Citizen
    {
        public Working(string name, string surname, string passportID) : base(name, surname, passportID)
        {

        }
    }
}

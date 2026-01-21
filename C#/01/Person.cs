using System;
using System.Collections.Generic;

namespace _01
{
    public class Person
    {
        public Person(string firstName, string lastName, DateOnly birthDate)
        {
            First = firstName;
            Last = lastName;
            BirthDate = birthDate;
            Pets = new List<Pet>();
        }

        public string First { get; }
        public string Last { get; }
        public DateOnly BirthDate { get; }
        public List<Pet> Pets { get; }

        public override string ToString() => $"{First} {Last} (born {BirthDate:yyyy-MM-dd})";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => $"{FirstName} {LastName}";

        public Person(string? firstName, string? lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Indtast fornavn");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Indtast efternavn");

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FullName}";
        }
    }
}

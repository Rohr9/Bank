using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Person : PersonBase
    {
        public Person(int customerID, string firstName, string lastName)
            : base(customerID, firstName, lastName) { }
    }

    public class Admin : PersonBase
    {
        public Admin(int employeeID, string firstName, string lastName)
            : base(employeeID, firstName, lastName) { }
    }
}

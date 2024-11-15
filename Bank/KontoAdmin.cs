using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public sealed class KontoAdmin : PersonBase
    {
        public int EmployeeID { get; }

        public KontoAdmin(int employeeID, string firstName, string lastName)
            : base(employeeID, firstName, lastName)
        {
            if (employeeID.ToString().Length != 6)
                throw new ArgumentException("EmployeeID must be a 6-digit number.");

            EmployeeID = employeeID;
        }
    }
}

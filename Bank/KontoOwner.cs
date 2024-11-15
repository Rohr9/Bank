using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public sealed class KontoOwner : PersonBase
    {
        public int CustomerID { get; }

        public KontoOwner(int customerID, string firstName, string lastName)
            : base(customerID, firstName, lastName)
        {
            if (customerID.ToString().Length != 6)
                throw new ArgumentException("CustomerID must be a 6-digit number.");

            CustomerID = customerID;
        }
    }
}

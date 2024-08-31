using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class Customer
    {
        public string name;
        public string surname;
        public string phoneNumber;
        public float spending;
        public int goodiesBrought;

        public Customer(string name, string surname, string phoneNumber, float spending, int goodies) 
        {
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.spending = spending;
            this.goodiesBrought = goodies;
        
        }
    }
}

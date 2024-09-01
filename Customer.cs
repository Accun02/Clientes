using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class Customer
    {
        public string Name;
        public string Surname;
        public string PhoneNumber;
        public float Spending;
        public int Purcharse;

        public Customer(string name, string surname, string phoneNumber, float spending, int goodies) 
        {
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.Spending = spending;
            this.Purcharse = goodies;
        
        }
    }
}

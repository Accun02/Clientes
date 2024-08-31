using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class DictionaryManager
    {
        private Dictionary<int, Customer> customerDictionary;
        private int initialCustomers = 5;

        public void Initialize (Dictionary<int, Customer> CustomerDictionary) 
        {
            customerDictionary = CustomerDictionary;

            for (int i = 0; i < initialCustomers; i++) 
            {
                Customer client = AddCustomer($"Customer {i}", " Buyergoodin", "1111", 100 + i, 1);
                customerDictionary.Add(100 + i, client);
            }
        }


        private Customer AddCustomer(string name, string surname, string phoneNumber, float spending, int goodies) 
        {
            return new Customer(name, surname, phoneNumber, spending, goodies);
        }

        public void writeCustomers() 
        {
            for (int i = 0; i < customerDictionary.Count; i++)
            {
                Customer client = customerDictionary[100 + i];
                Console.WriteLine($"Customer name: {client.name}" + $"{client.surname}\n" +
                                   $"Phone Number: {client.phoneNumber}\n" + $"Spending: {client.spending}\n" +
                                   $"Goodies brought: {client.goodiesBrought}\n\n");
            }
        }
    }
}

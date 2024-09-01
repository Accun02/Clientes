using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Reflection.Metadata.Ecma335;

namespace TelephoneLine
{
    public class DictionaryManager
    {
        private Random rnd = new Random();
        private Random rndnumber = new Random();
        private string[] names = ["Jeppeto", "Jane", "Juan", "Andres" ];
        private string[] surnames = ["doe", "Dough","ez", "Buyergoodin"];
 
        int number;
        private Dictionary<int, Customer> customerDictionary;
        private int initialCustomers = 5;

        private RegisterClient registerClient;

        public void Initialize (Dictionary<int, Customer> CustomerDictionary) 
        {

            customerDictionary = CustomerDictionary;
            registerClient = new RegisterClient (customerDictionary);
            for (int i = 0; i < initialCustomers; i++) 
            {
                string Phonenumber = string.Empty;
                number = 0;
                int namesIndex = rnd.Next(names.Length);
                int surnamesIndex = rnd.Next(surnames.Length);
     
                for (int j = 0; j < 8; j++) 
                {
                    int number = rndnumber.Next(0, 9);
                    Phonenumber += (number.ToString());

                }
                Customer client = AddCustomer($"{names[namesIndex]} ", $"{surnames[surnamesIndex]}", $"{Phonenumber}", rndnumber.Next(1,500), rnd.Next (1,20));
                customerDictionary.Add(100 + i, client);
            }
        }


        private Customer AddCustomer(string name, string surname, string phoneNumber, float spending, int goodies)  // creador de usuarios
        {
            return new Customer(name, surname, phoneNumber, spending, goodies);
        }

        public void writeCustomers() 
        {
            List<int> idKeys = customerDictionary.Keys.ToList();

            Console.WriteLine("----- ID KEYS STORED -----\n");
            for (int i = 0; i < idKeys.Count; i++)
            {
                Console.WriteLine(idKeys[i]);

                Customer client = customerDictionary[100 + i];
                Console.WriteLine($"Customer name: {client.Name}" + $"{client.Surname}\n" +
                                   $"Phone Number: {client.PhoneNumber}\n" + $"Spending: {client.Spending}\n" +
                                  $"Goodies brought: {client.Purcharse}\n\n");
            }
            Console.WriteLine("\n----- *************** -----");

            registerClient.InsertClient();
        }
    }
}

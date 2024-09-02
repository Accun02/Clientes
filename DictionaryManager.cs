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
        private string[] names = ["Geto", "Jane", "Juan", "Andres", "Barrakas" ];
        private string[] surnames = ["Dou", "Invenias","Ez", "Buyergoodin"];
 
        int number;
        private Dictionary<int, Customer>? customerDictionary;
        private int initialCustomers = 5;

        private RegisterClient registerClient;

        public void Initialize (Dictionary<int, Customer> CustomerDictionary) 
        {

            customerDictionary = CustomerDictionary;
            registerClient = new RegisterClient (customerDictionary);
            for (int i = 0; i < initialCustomers; i++) 
            {
                string Phonenumber = string.Empty;
                string Id = string.Empty;
                number = 0;
                int namesIndex = rnd.Next(names.Length);
                int surnamesIndex = rnd.Next(surnames.Length);
                
     
                for (int j = 0; j < 8; j++) 
                {
                    int number = rndnumber.Next(0, 9);
                    Phonenumber += (number.ToString());

                    int idNum = rndnumber.Next(0, 9);
                    Id += (idNum.ToString());
                }
                int.TryParse(Id, out int resultID);

                Customer client = AddCustomer($"{names[namesIndex]} ", $"{surnames[surnamesIndex]}", $"{Phonenumber}", rndnumber.Next(1,500), rnd.Next (1,20));
                customerDictionary.Add(resultID, client);
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

                Customer client = customerDictionary[idKeys[i]];
                Console.WriteLine($"Customer name: {client.Name}" + $"{client.Surname}\n" +
                                   $"Phone Number: {client.PhoneNumber}\n" + $"Spending: {client.Spending}\n" +
                                  $"Goodies brought: {client.Purcharse}\n\n");
            }
            Console.WriteLine("\n----- *************** -----");

            registerClient.InsertClient();
            writeCustomers();
        }
    }
}

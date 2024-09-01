using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class RegisterClient
    {
        Dictionary<int, Customer> registercustomer;
        public RegisterClient( Dictionary <int,Customer> registercustomer) 
        {
            this.registercustomer = registercustomer;
        }
        enum Registry 
        {
            enterID, enterName, enterSurname, 
            enterPhone, enterSpenses, 
            enterPurchases, existingID, endRegister,
            OldCostumer
        }

        private Registry registry = new Registry();


        int id;
        string? name = null;
        string? surname = null;
        string? phoneNumber = null;
        int? expenses = null;
        int? purchases = null;

        public void InsertClient()
        {
            bool enterACustomer = false;

            while (!enterACustomer)
            {
                switch (registry)
                {
                    case Registry.enterID:

                        Console.WriteLine("\n1- Write a ID (3 numbers): \n");

                        string temp = Console.ReadLine();


                        if (!int.TryParse(temp, out int ident))
                        {
                            Console.WriteLine("\nIncorrect values\n");
                            continue;
                        }
                        else
                        {
                            id = ident;
                            
                        }
                        if (registercustomer[id].
                        {
                            
                        }
                        
                        registry = Registry.enterName;
                        break;

                    case Registry.enterName:

                        Console.WriteLine("\n2- Write a name: \n");

                        name = Console.ReadLine();

                        if(name == null) 
                        {
                            Console.WriteLine("\nName cannot be empty\n");
                            continue;
                        }
                        registry = Registry.enterSurname;
                        break;

                    case Registry.enterSurname:

                        Console.WriteLine("\n3- Write a surname: \n");
                        
                        surname = Console.ReadLine();
                        
                        if(surname == null) 
                        {
                            Console.WriteLine("\nSurname must not be empty\n");
                            continue;
                        }
                        registry = Registry.enterPhone;

                    break;

                    case Registry.enterPhone:

                        Console.WriteLine("\n4- Write a phone number (8 characters): \n");

                        phoneNumber = Console.ReadLine();
                        
                        if (phoneNumber == null || phoneNumber.Any(char.IsLetter)) 
                        {
                            Console.WriteLine("\nThere must be a phone number somewhere. Go get it.\n");
                            continue;
                        } 
                        else if (phoneNumber.Length < 8 || phoneNumber.Length > 10 || phoneNumber.Any(char.IsLetter)) 
                        {
                            Console.WriteLine("\nThat phone number is invalid\n");
                            continue;
                        }
                        registry = Registry.enterSpenses;

                    break;

                    case Registry.enterSpenses:

                        Console.WriteLine("\n5- Enter expenses: \n");
                        
                        string? input = Console.ReadLine();
                        if(!int.TryParse(input, out int result)) 
                        {
                            Console.WriteLine("\nIncorrect values\n");
                            continue;
                        } 
                        else 
                        {
                            expenses = result;
                            registry = Registry.enterPurchases;
                        }
                    break;


                    case Registry.enterPurchases:

                        Console.WriteLine("\n6- Enter the number of purchases: \n");

                        string? inputPurchase = Console.ReadLine();

                        if(!int.TryParse(inputPurchase, out int resultPurchase)) 
                        {
                            Console.WriteLine("\nIncorrect values \n");
                            continue;
                        }
                        else
                        {
                            purchases = resultPurchase;
                            registry = Registry.endRegister;
                        }
                    break;

                    case Registry.endRegister:

                        Console.WriteLine($"\nID: {id}\n" +
                                          $"Customer name: {name}" + $" {surname}\n" +
                                          $"Phone Number: {phoneNumber}\n" + $"Spending: {expenses}\n" +
                                          $"Goodies brought: {purchases}\n\n");

                        enterACustomer = true;
                        break;
                }
            }
        }
    }
}

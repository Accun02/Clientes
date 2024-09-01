using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class RegisterClient
    {
        Dictionary<int, Customer> registerCustomer;
        public RegisterClient( Dictionary <int,Customer> registerCustomer) 
        {
            this.registerCustomer = registerCustomer;
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
        int? spending = null;
        int? purchases = null;

        public void InsertClient() // Agregar un cliente nuevo o viejo
        {
            bool enterACustomer = false;
            Customer? customer1 = null;

            while (!enterACustomer)
            {
                switch (registry)
                {
                    case Registry.enterID: //ingresas documento

                        Console.WriteLine("\n1- Write a ID (3 numbers): \n");

                        string temp = Console.ReadLine();


                        if (!int.TryParse(temp, out int ident)) // si el doc tiene letras
                        {
                            Console.WriteLine("\nIncorrect values\n");
                            continue;
                        }
                        else
                        {
                            id = ident;
                            
                        }
                        if (registerCustomer.TryGetValue(id, out Customer? customer)) // si la id ya esta registrada
                        {
                            Console.WriteLine("obtiene valor");
                            registry = Registry.enterSpenses;
                            customer1 = customer;
                        }
                        else // si no
                        {
                            registry = Registry.enterName;
                        }
                       
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
                        else  if ( customer1 == null) //no existe el cliente
                        {
                            spending = result;
                            registry = Registry.enterPurchases;
                        }
                        else if (customer1 != null) // existe cliente
                        {
                            customer1.Spending += result;
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
                       if (customer1 == null) //  no existe cliente y agraga las compras
                        {

                            purchases = resultPurchase;
                            registry = Registry.endRegister;
                        }
                        else if (customer1 != null) // existe cliente y le suma las compras
                        {
                            customer1.Purcharse += resultPurchase;
                            registry = Registry.endRegister;
                        }
                    break;

                    case Registry.endRegister:

                        if (customer1 == null) //datos del nuevo usuario
                        {
                            Console.WriteLine($"\nID: {id}\n" +
                                                                     $"Customer name: {name}" + $" {surname}\n" +
                                                                     $"Phone Number: {phoneNumber}\n" + $"Spending: {spending}\n" +
                                                                     $"Goodies brought: {purchases}\n\n");
                        }
                       
                        else if (customer1 != null)  //datos del usuario ya registrado
                        {
                            Console.WriteLine($"\nID: {id}\n" +
                                                                     $"Customer name: {customer1.Name}" + $" {customer1.Surname}\n" +
                                                                     $"Phone Number: {customer1.PhoneNumber}\n" + $"Spending: {customer1.Spending}\n" +
                                                                     $"Goodies brought: {customer1.Purcharse}\n\n");
                        }

                        enterACustomer = true;
                        break;
                }
            }
        }
    }
}

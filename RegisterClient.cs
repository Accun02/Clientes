using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class RegisterClient
    {
        enum Registry 
        {
            enterID, enterName, enterSurname, 
            enterPhoneNumber, enterSpenses, 
            enterPurchases, existingID
        }

        private Registry registry = new Registry();
        private void InsertClient()
        {
            bool enterACustomer = false;

            while (!enterACustomer)
            {
                switch (registry)
                {
                    case Registry.enterID:

                        Console.WriteLine("Write a ID: ");

                        string? ID = Console.ReadLine();

                        if (ID == null || ID.Any(char.IsLetter))
                        {
                            Console.WriteLine("Invalid ID");
                            continue;
                        }
                        
                        registry = Registry.enterName;
                        break;

                    case Registry.enterName:

                        Console.WriteLine("Write a Name: ");

                        string? name = Console.ReadLine();

                        break;
                }
            }
        }
    }
}

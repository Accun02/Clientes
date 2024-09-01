using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class StepEnterPurchases : IRegistrySteps
    {
        RegisterClient _client;
        public StepEnterPurchases(RegisterClient client) 
        {
            _client = client;
        }

        public void RunUpdate() 
        {
            Console.WriteLine("\n6- Enter the number of purchases: \n");

            string? inputPurchase = Console.ReadLine();

            if (!int.TryParse(inputPurchase, out int resultPurchase))
            {
                Console.WriteLine("\nIncorrect values \n");
                return;
            }
            if (!_client.CustomerAccesed) //  no se accedio al cliente y agrega las compras
            {
                _client.Purchases = resultPurchase;
                _client.ChangeStep(_client.StepEndRegister);
            }
            else if (_client.CustomerAccesed) // se accedio a un cliente y le suma las compras
            {
                _client.Customer.Purcharse += resultPurchase;
                _client.ChangeStep(_client.StepEndRegister);
            }
        }
    }
}

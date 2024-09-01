using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class StepEnterExpenses : IRegistrySteps
    {
        RegisterClient _client;

        public StepEnterExpenses(RegisterClient client)
        {
            _client = client;
        }

        public void RunUpdate() 
        {
            Console.WriteLine("\n5- Enter expenses: \n");

            string? input = Console.ReadLine();
            if (!float.TryParse(input, out float result))
            {
                Console.WriteLine("\nIncorrect values\n");
                return;
            }
            else if (_client.Customer == null) //no existe el cliente
            {
                _client.Spending = result;
                _client.ChangeStep(_client.StepEnterPurchases);
            }
            else if (_client.Customer != null) // existe cliente
            {
                _client.Customer.Spending += result;
                _client.ChangeStep(_client.StepEnterPurchases);
            }
        }
    }
}

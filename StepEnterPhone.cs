using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class StepEnterPhone : IRegistrySteps
    {
        RegisterClient _client;

        public StepEnterPhone(RegisterClient client)
        {
            _client = client;
        }

        public void RunUpdate() 
        {
            Console.WriteLine("\n4- Write a phone number (8 characters): \n");

            _client.PhoneNumber = Console.ReadLine();

            if (_client.PhoneNumber == null || _client.PhoneNumber.Any(char.IsLetter))
            {
                Console.WriteLine("\nThere must be a phone number somewhere. Go get it.\n");
                return;
            }
            else if (_client.PhoneNumber.Length < 8 || _client.PhoneNumber.Length > 10 || _client.PhoneNumber.Any(char.IsLetter))
            {
                Console.WriteLine("\nThat phone number is invalid\n");
                return;
            }

            _client.ChangeStep(_client.StepEnterExpenses);
        }
    }
}

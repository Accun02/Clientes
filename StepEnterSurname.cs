using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class StepEnterSurname : IRegistrySteps
    {
        RegisterClient _client;

        public StepEnterSurname(RegisterClient client)
        {
            _client = client;
        }
        
        public void RunUpdate() 
        {
            Console.WriteLine("\n3- Write a surname: \n");

            _client.Surname = Console.ReadLine();

            if (_client.Surname == null)
            {
                Console.WriteLine("\nSurname must not be empty\n");
                return;
            }
            _client.ChangeStep(_client.StepEnterPhone);
        }
    }
}

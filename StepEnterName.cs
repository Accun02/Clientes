using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TelephoneLine
{
    public class StepEnterName : IRegistrySteps
    {
        RegisterClient? _client;

        public StepEnterName(RegisterClient registerClient) 
        {
            _client = registerClient;
        }
        public void RunUpdate() 
        {
            Console.WriteLine("\n2- Write a name: \n");

            _client.Name = Console.ReadLine();

            if (_client.Name == null)
            {
                Console.WriteLine("\nName cannot be empty\n");
                return;
            }
            _client.ChangeStep(_client.StepEnterSurname);
        }
    }
}

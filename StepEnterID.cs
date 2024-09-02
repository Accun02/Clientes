using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class StepEnterID : IRegistrySteps
    {
        RegisterClient _client;

        public StepEnterID(RegisterClient registerClient) 
        {
            if(registerClient != null) 
            {
                _client = registerClient;
            }
        }

        public void RunUpdate() 
        {
            Console.WriteLine("\n1- Write a ID (8 numbers): \n");

            string? temp = Console.ReadLine();


            if (!int.TryParse(temp, out int ident) || temp.Length < 7) // si el doc tiene letras
            {
                Console.WriteLine("\nIncorrect values\n");
                return;
            }
            else
            {
                _client.Id = ident;
            }
            if (_client.RegisterCustomer.TryGetValue(_client.Id, out Customer? customer)) // si la id ya esta registrada
            {
                _client.ChangeStep(_client.StepEnterExpenses);
                _client.Customer = customer;
            }
            else 
            {
                _client.ChangeStep(_client.StepEnterName);
            }
        }
    }
}

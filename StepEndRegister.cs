using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TelephoneLine
{
    public class StepEndRegister : IRegistrySteps
    {
        RegisterClient _client;
        public StepEndRegister(RegisterClient client) 
        {
            _client = client;
        }

        public void RunUpdate()
        {
            if (_client.Customer == null) //datos del nuevo usuario
            {
                Console.WriteLine($"\nID: {_client.Id}\n" +
                                  $"Customer name: {_client.Name}" + $" {_client.Surname}\n" +
                                  $"Phone Number: {_client.PhoneNumber}\n" + $"Spending: {_client.Spending}\n" +
                                  $"Goodies brought: {_client.Purchases}\n\n");
            }

            else if (_client.Customer != null)  //datos del usuario ya registrado
            {
                Console.WriteLine($"\nID: {_client.Id}\n" +
                                  $"Customer name: {_client.Customer.Name}" + $" {_client.Customer.Surname}\n" +
                                  $"Phone Number: {_client.Customer.PhoneNumber}\n" + $"Spending: {_client.Customer.Spending}\n" +
                                  $"Goodies brought: {_client.Customer.Purcharse}\n\n");
            }

            _client.EnterACustomer = true;

            if(_client.Customer == null) 
            {
                _client.Customer = new Customer(_client.Name, _client.Surname, _client.PhoneNumber, _client.Spending, _client.Purchases);
            }
            _client.RegisterCustomer.TryAdd(_client.Id, _client.Customer);
        }
    }
}

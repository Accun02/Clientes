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
            if (_client.Customer == null) //  no se accedio al cliente y agrega las compras
            {
                _client.Purchases += 1;
                _client.ChangeStep(_client.StepEndRegister);
            }
            else if (_client.Customer != null) // se accedio a un cliente y le suma las compras
            {
                _client.Customer.Purcharse += 1;
                _client.ChangeStep(_client.StepEndRegister);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes
{
    internal class BuyManager
    {
        Dictionary<int, Clientes> Iddiccionary;
        public BuyManager(Dictionary<int,Clientes> id) 
        {
            Iddiccionary = id;
        }
        void start()
        {
            for (int i = 0; i < 4; i++)
            {
                Iddiccionary[i] = new Clientes();
            }
        }
    }
}

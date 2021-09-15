using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismGettingStarted.Services
{
    class DBCustomerStore : ICustomerStore
    {
        public List<string> GetAll()
        {
            var list = new List<string>();
            list.Add("Customer Number One");
            list.Add("Customer Number Two");
            list.Add("Customer Number Three");
            return list;
        }
    }
}

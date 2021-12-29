using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StarbucksCustomer :IEntity
    {
        public int StrbCustomerId { get; set; }

        public int CustomerId { get; set; }

        public bool IsPremiumMember { get; set; }

        public string HomeTown { get; set; }
    }
}

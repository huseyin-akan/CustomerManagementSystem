using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PortalCustomer : IEntity
    {
        public int PrtlCustomerId { get; set; }
        public int CustomerId { get; set; }

        public string PlaceOfBirth { get; set; }

        public string FavouriteSportTeam { get; set; }

    }
}

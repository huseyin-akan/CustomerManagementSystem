using Core.DataAccess.EntityFrameWork;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPortalCustomerDal : IEntityRepository<PortalCustomer>
    {
        public PortalCustomerDto GetPortalCustomerByPortalId(int portalCustomerId);
        public PortalCustomerDto GetPortalCustomerByCustomerId(int customerId);
    }
}

using Core.Utilities.Results;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortalCustomerService
    {
        public DataResult<PortalCustomerDto> getPortalCustomerByCustomerId(int customerId);
        public DataResult<PortalCustomerDto> getPortalCustomerByPortalId(int portalId);
        public Result addCustomer(PortalCustomerDto portalCustomerDto);
    }
}

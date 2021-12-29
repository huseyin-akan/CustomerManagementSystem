using Core.Utilities.Results;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStarbucksCustomerService
    {
        public DataResult<StarbucksCustomerDto> getStarbucksCustomerByCustomerId(int customerId);
        public DataResult<StarbucksCustomerDto> getStarbucksCustomerByStarbucksId(int starbucksId);
        public Result addCustomer(StarbucksCustomerDto starbucksCustomerDto);
    }
}

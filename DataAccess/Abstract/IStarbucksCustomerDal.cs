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
    public interface IStarbucksCustomerDal :IEntityRepository<StarbucksCustomer>
    {
        public StarbucksCustomerDto GetStarbucksCustomerByStarbucksId(int starbucksCustomerId);
        public StarbucksCustomerDto GetStarbucksCustomerByCustomerId(int customerId);
    }
}

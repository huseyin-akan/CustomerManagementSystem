using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CustomerManagamentContext>, ICustomerDal
    {
        public bool CustomerExists(int customerId)
        {
            var result = Get(c => c.CustomerId == customerId);

            if (result == null)
            {
                return false;
            }

            return true;
        }

        public bool GetMernisValidation(Customer customer)
        {
            return true;
        }
    }
}

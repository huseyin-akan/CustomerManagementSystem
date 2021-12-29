using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public abstract class CustomerManagerBase : ICustomerService
    {
        //Common methods that all customer manager classes will use
        public Result UpdateCustomer(Customer customer)
        {
            return new SuccessResult("Customer info has been updated");
        }
    }
}

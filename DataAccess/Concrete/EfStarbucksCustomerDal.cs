using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfStarbucksCustomerDal : EfEntityRepositoryBase<StarbucksCustomer, CustomerManagamentContext>, IStarbucksCustomerDal
    {
        public StarbucksCustomerDto GetStarbucksCustomerByStarbucksId(int starbucksCustomerId)
        {
            using (CustomerManagamentContext context = new CustomerManagamentContext())
            {
                var result = from s in context.StarbucksCustomers
                             join c in context.Customers
                             on s.CustomerId equals c.CustomerId
                             where s.StrbCustomerId == starbucksCustomerId
                             select new StarbucksCustomerDto
                             {
                                 StrbCustomerId = s.StrbCustomerId,
                                 CustomerId = s.CustomerId,
                                 NationalityId = c.NationalityId,
                                 BirthDate = c.BirthDate,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Email = c.Email,
                                 UserName = c.UserName,
                                 HomeTown = s.HomeTown,
                                 IsPremiumMember = s.IsPremiumMember
                             };
                return result.FirstOrDefault();
            }
        }

        public StarbucksCustomerDto GetStarbucksCustomerByCustomerId(int customerId)
        {
            using (CustomerManagamentContext context = new CustomerManagamentContext())
            {
                var result = from s in context.StarbucksCustomers
                             join c in context.Customers
                             on s.CustomerId equals c.CustomerId
                             where c.CustomerId == customerId
                             select new StarbucksCustomerDto
                             {
                                 StrbCustomerId = s.StrbCustomerId,
                                 CustomerId = s.CustomerId,
                                 NationalityId = c.NationalityId,
                                 BirthDate = c.BirthDate,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Email = c.Email,
                                 UserName = c.UserName,
                                 HomeTown = s.HomeTown,
                                 IsPremiumMember = s.IsPremiumMember
                             };
                return result.FirstOrDefault();
            }
        }
    }
}

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
    public class EfPortalCustomerDal : EfEntityRepositoryBase<PortalCustomer, CustomerManagamentContext>, IPortalCustomerDal
    {
        public PortalCustomerDto GetPortalCustomerByPortalId (int portalCustomerId)
        {
            using (CustomerManagamentContext context = new CustomerManagamentContext())
            {
                var result = from p in context.PortalCustomers
                             join c in context.Customers
                             on p.CustomerId equals c.CustomerId
                             where p.PrtlCustomerId == portalCustomerId
                             select new PortalCustomerDto
                             {
                                 PrtlCustomerId = p.PrtlCustomerId,
                                 CustomerId = p.CustomerId,
                                 NationalityId = c.NationalityId,
                                 BirthDate = c.BirthDate,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Email = c.Email,
                                 UserName = c.UserName,
                                 FavouriteSportTeam = p.FavouriteSportTeam,
                                 PlaceOfBirth = p.PlaceOfBirth
                             };
                return result.FirstOrDefault();
            }          
        }

        public PortalCustomerDto GetPortalCustomerByCustomerId(int customerId)
        {
            using (CustomerManagamentContext context = new CustomerManagamentContext())
            {
                var result = from p in context.PortalCustomers
                             join c in context.Customers
                             on p.CustomerId equals c.CustomerId
                             where c.CustomerId == customerId
                             select new PortalCustomerDto
                             {
                                 PrtlCustomerId = p.PrtlCustomerId,
                                 CustomerId = p.CustomerId,
                                 NationalityId = c.NationalityId,
                                 BirthDate = c.BirthDate,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Email = c.Email,
                                 UserName = c.UserName,
                                 FavouriteSportTeam = p.FavouriteSportTeam,
                                 PlaceOfBirth = p.PlaceOfBirth
                             };
                return result.FirstOrDefault();
            }
        }
    }
}

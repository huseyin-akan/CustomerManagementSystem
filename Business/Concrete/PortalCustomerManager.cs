using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PortalCustomerManager : CustomerManagerBase, IPortalCustomerService
    {
        private ICustomerDal customerDal;
        private IPortalCustomerDal portalCustomerDal;

        public PortalCustomerManager(ICustomerDal customerDal, IPortalCustomerDal portalCustomerDal)
        {   
            this.customerDal = customerDal;
            this.portalCustomerDal = portalCustomerDal;
        }

        public Result addCustomer(PortalCustomerDto portalCustomerDto)
        {
            //Check if that customer exists ; if yes no need to add, if no we need to add
            if (!customerDal.CustomerExists(portalCustomerDto.CustomerId))
            {
                customerDal.Add(new Customer
                {
                    CustomerId = portalCustomerDto.CustomerId,
                    BirthDate = portalCustomerDto.BirthDate,
                    Email = portalCustomerDto.Email,
                    FirstName = portalCustomerDto.FirstName,
                    LastName = portalCustomerDto.LastName,
                    NationalityId = portalCustomerDto.NationalityId,
                    UserName = portalCustomerDto.UserName
                });
            }

            //Check if starbucks customer exists, if yes no need to add, if no we add
            if (!PortalCustomerExists(portalCustomerDto.PrtlCustomerId))
            {
                portalCustomerDal.Add(new PortalCustomer
                {
                    CustomerId = portalCustomerDto.CustomerId,
                    FavouriteSportTeam = portalCustomerDto.FavouriteSportTeam,
                    PlaceOfBirth = portalCustomerDto.PlaceOfBirth
                });
                return new SuccessResult(Messages.PortalCustomerAdded);
            }

            return new ErrorResult(Messages.PortalCustomerNotAdded);
        }

        public DataResult<PortalCustomerDto> getPortalCustomerByCustomerId(int customerId)
        {
            return new SuccessDataResult<PortalCustomerDto>(this.portalCustomerDal.GetPortalCustomerByCustomerId(customerId));
        }

        public DataResult<PortalCustomerDto> getPortalCustomerByPortalId(int portalId)
        {
            return new SuccessDataResult<PortalCustomerDto>(this.portalCustomerDal.GetPortalCustomerByPortalId(portalId));
        }

        public bool PortalCustomerExists(int portalCustomerId)
        {
            var result = portalCustomerDal.Get(p => p.PrtlCustomerId == portalCustomerId);

            if (result == null)
            {
                return false;
            }
            return true;
        }


        }
    }

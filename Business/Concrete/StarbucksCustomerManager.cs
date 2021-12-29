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
    public class StarbucksCustomerManager : IStarbucksCustomerService
    {
        private ICustomerDal customerDal;
        private IStarbucksCustomerDal starbucksCustomerDal;
        private IMernisService mernisService;

        public StarbucksCustomerManager(ICustomerDal customerDal, IStarbucksCustomerDal starbucksCustomerDal, IMernisService mernisService)
        {
            this.customerDal = customerDal;
            this.starbucksCustomerDal = starbucksCustomerDal;
            this.mernisService = mernisService;
        }

        public Result addCustomer(StarbucksCustomerDto starbucksCustomerDto)
        {
            var customerToCheck = new Customer
            {
                CustomerId = starbucksCustomerDto.CustomerId,
                BirthDate = starbucksCustomerDto.BirthDate,
                Email = starbucksCustomerDto.Email,
                FirstName = starbucksCustomerDto.FirstName,
                LastName = starbucksCustomerDto.LastName,
                NationalityId = starbucksCustomerDto.NationalityId,
                UserName = starbucksCustomerDto.UserName
            };

            //Mernis Validation
            if (!mernisService.GetMernisValidation(customerToCheck))
            {
                return new ErrorResult(Messages.MernisValidationFailed);
            }


            //Check if that customer exists ; if yes no need to add, if no we need to add
            if (!customerDal.CustomerExists(starbucksCustomerDto.CustomerId))
            {
                customerDal.Add(customerToCheck);
            }

            //Check if starbucks customer exists, if yes no need to add, if no we add
            if (!StarBucksCustomerExists(starbucksCustomerDto.StrbCustomerId))
            {
                starbucksCustomerDal.Add(new StarbucksCustomer
                {
                    CustomerId = starbucksCustomerDto.CustomerId,
                    HomeTown = starbucksCustomerDto.HomeTown,
                    IsPremiumMember = starbucksCustomerDto.IsPremiumMember
                });
                return new SuccessResult(Messages.StarbucksCustomerAdded);
            }

            return new ErrorResult(Messages.StarbucksCustomerNotAdded);            
        }

        public DataResult<StarbucksCustomerDto> getStarbucksCustomerByCustomerId(int customerId)
        {
            return new SuccessDataResult<StarbucksCustomerDto>(this.starbucksCustomerDal.GetStarbucksCustomerByCustomerId(customerId));
        }

        public DataResult<StarbucksCustomerDto> getStarbucksCustomerByStarbucksId(int starbucksId)
        {
            return new SuccessDataResult<StarbucksCustomerDto>(this.starbucksCustomerDal.GetStarbucksCustomerByStarbucksId(starbucksId));
        }       

        public bool StarBucksCustomerExists(int starbuckCustomerId)
        {
            var result = starbucksCustomerDal.Get(s => s.StrbCustomerId== starbuckCustomerId);

            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}

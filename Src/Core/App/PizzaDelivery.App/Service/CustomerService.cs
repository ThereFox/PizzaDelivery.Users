using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.Interfaces.Service;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Src.Core.Common;

namespace Src.Core.App.Service
{
    public class CustomerService
    {
        private readonly ICurrentCustomerInfoGetter _current;
        private readonly ICustomerStore _customerStore;

        public CustomerService(
            ICurrentCustomerInfoGetter currentService,
            ICustomerStore customerStore
            )
        {
            _current = currentService;
            _customerStore = customerStore;
        }

        public async Task<Customer> GetInfoByCurrentUser()
        {
            var authInfo = _current.Get();

            var getCustomerResult = await _customerStore.GetById(authInfo.CustomerId);

            if(getCustomerResult.IsSucsesfull == false)
            {
                throw new Exception("authed user cannot be getted");
            }

            return getCustomerResult.ResultValue;

        }
        public async Task<Result<Address>> GetMostUsableAddresForCurrentUser()
        {
            var authInfo = _current.Get();

            var getAddresResult = await _customerStore.GetMostUseableAddresForUser(authInfo.CustomerId);

            if(getAddresResult.IsSucsesfull == false)
            {
                return Result.Failure<Address>(getAddresResult.ErrorInfo);
            }

            return Result.Sucsesfull(getAddresResult.ResultValue);
        }
        public async Task<Result> UpdateCustomerInfo(Customer customer)
        {
            var UpdateCustomerInfoResult = await _customerStore.Update(customer);
        
            return UpdateCustomerInfoResult;
        }


    }
}
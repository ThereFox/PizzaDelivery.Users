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
        public async Task<Result<Customer>> GetById(Guid id)
        {
            var getCustomerResult = await _customerStore.GetById(id);

            return getCustomerResult;
        }
        public async Task<Result<Customer>> GetInfoByCurrentUser()
        {
            var authInfo = _current.Get();

            if(authInfo.IsSucsesfull == false)
            {
                return Result.Failure<Customer>(new Error("123", "user dont have auth"));
            }

            var getCustomerResult = await _customerStore.GetById(authInfo.ResultValue.CustomerId);

            if(getCustomerResult.IsSucsesfull == false)
            {
                return Result.Failure<Customer>(new Error("123", "authed user cannot be getted"));
            }

            return Result.Sucsesfull(getCustomerResult.ResultValue);

        }
        public async Task<Result<Address>> GetMostUsableAddresForCurrentUser()
        {
            var getAuthInfoResult = _current.Get();

            if(getAuthInfoResult.IsSucsesfull == false)
            {
                return Result.Failure<Address>(getAuthInfoResult.ErrorInfo);
            }

            var getAddresResult = await _customerStore.GetMostUseableAddresForUser(getAuthInfoResult.ResultValue.CustomerId);

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
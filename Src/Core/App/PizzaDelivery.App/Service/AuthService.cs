using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Common;
using PizzaDelivery.App.DTO;
using PizzaDelivery.App.Interfaces;
using PizzaDelivery.App.Interfaces.Tokens;
using PizzaDelivery.Core.App.Interfaces;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Core.App.Service
{
    public class AuthService
    {
        private ITokensStore _tokensStore;
        private ICustomerStore _customerStore;
        private ITokenChecker _checker;
        private ITokenGenerator _generator;

        public AuthService(
            ITokensStore TokenStore,
            ICustomerStore CustomerStore)
        {
            _tokensStore = TokenStore;
            _customerStore = CustomerStore;
        }

        public Result Registrate(Customer customer, string password)
        {
            return Result.Sucsesfull();
        }

        public async Result<Customer> AuthoriseByTokens(AuthBearer bearer)
        {
            var validationResult = await _checker.IsValidToken(bearer.AuthToken);

            if(validationResult.IsSucsesfull == false)
            {
                return Result.Failure(validationResult.ErrorInfo);
            }

            var TokenAuthInfo = _checker.GetCustomerInfo(bearer.AuthToken);


            
        }
        public Result<AuthBearer> Authorise(Phone phone, string password)
        {
            return Result.Failure<AuthBearer>(new Error("123", "error"));
        }

    }
}
using PizzaDelivery.App.DTO;
using PizzaDelivery.App.Interfaces;
using PizzaDelivery.App.Interfaces.Tokens;
using PizzaDelivery.Core.App.Interfaces;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Core.App.Service
{
    public class TokenAuthService
    {
        private ITokensStore _tokensStore;
        private ICustomerStore _customerStore;
        private IAuthDataStore _authDataStore;
        private ITokenChecker _checker;
        private ITokenGenerator _generator;
        private IHashGetter _hashGetter;

        public TokenAuthService(
            ITokensStore TokenStore,
            ICustomerStore CustomerStore,
            IAuthDataStore AuthDataStore,
            ITokenChecker TokenChecker,
            ITokenGenerator TokenGenerator,
            IHashGetter HashGetter
            )
        {
            _tokensStore = TokenStore;
            _customerStore = CustomerStore;
            _authDataStore = AuthDataStore;
            _checker = TokenChecker;
            _generator = TokenGenerator;
            _hashGetter = HashGetter;
        }

        public async Task<Result> Registrate(CustomerRegistrateInfo registrateInfo)
        {
            var getCustomerWithThisPhoneResult = await _customerStore.GetByPhone(registrateInfo.Phone);

            if(getCustomerWithThisPhoneResult.IsSucsesfull)
            {
                return Result.Failure(new Error("123", "this phone now busy"));
            }

            var CreateCustomerResult = await _authDataStore.CreateCustomer(registrateInfo);

            return CreateCustomerResult;
        }
        public async Task<Result<AuthBearer>> Authorise(Phone phone, string password)
        {
            if(password == null || password.Length == 0)
            {
                return Result.Failure<AuthBearer>(new Error("123", "password is null"));
            }

            var authoriseInfo = new CustomerAuthoriseInfo(phone, _hashGetter.GetHash(password));

            var checkCustomerExistResult = await _authDataStore.HaveCustomer(authoriseInfo);

            if(checkCustomerExistResult.IsSucsesfull == false)
            {
                return Result.Failure<AuthBearer>(checkCustomerExistResult.ErrorInfo);
            }

            var customer = await _customerStore.GetByPhone(phone);

            var newTokens = _generator.Generate(new TokenContent() { CustomerId = customer.ResultValue.Id});
            
            _tokensStore.SaveToken(newTokens.RefreshToken, customer.ResultValue.Id);
            
            return Result.Sucsesfull(newTokens);
        }
        public async Task<Result<Customer>> AuthoriseByAuthToken(string authToken)
        {
            var GetCustomerInfoFromTokenResult = await _checker.GetCustomerInfoFromToken(authToken);

            if(GetCustomerInfoFromTokenResult.IsSucsesfull == false)
            {
                return Result.Failure<Customer>(GetCustomerInfoFromTokenResult.ErrorInfo);
            }

            var GetCustomerResult = await _customerStore.GetById(GetCustomerInfoFromTokenResult.ResultValue.CustomerId);
        
            if(GetCustomerResult.IsSucsesfull == false)
            {
                return Result.Failure<Customer>(GetCustomerResult.ErrorInfo);
            }

            return Result.Sucsesfull<Customer>(GetCustomerResult.ResultValue);
        }
        public async Task<Result<AuthBearer>> RefreshTokens(string refreshToken)
        {
            var CheckTokenAliveResult = await _checker.IsRefreshTokenAlive(refreshToken);

            if(CheckTokenAliveResult.IsSucsesfull == false)
            {
                return Result.Failure<AuthBearer>(CheckTokenAliveResult.ErrorInfo);
            }

            if(await _tokensStore.HaveToken(refreshToken) == false)
            {
                return Result.Failure<AuthBearer>(new Error("123", "Token dont have exist"));
            }

            var getRefreshTokenOwnerResult = await _tokensStore.GetOwner(refreshToken);

            if(getRefreshTokenOwnerResult.IsSucsesfull == false)
            {
                return Result.Failure<AuthBearer>(new Error("123", "Token owner dont have exist"));
            }

            var tokenContent = new TokenContent() { CustomerId = getRefreshTokenOwnerResult.ResultValue.Id };

            var newTokens = _generator.Generate(tokenContent);

            _tokensStore.SaveToken(newTokens.RefreshToken, getRefreshTokenOwnerResult.ResultValue.Id);

            return Result.Sucsesfull(newTokens);

        }

    }
}
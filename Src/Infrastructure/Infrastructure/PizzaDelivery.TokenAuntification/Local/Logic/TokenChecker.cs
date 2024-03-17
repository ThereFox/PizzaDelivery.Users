using System.Security.Cryptography;
using System.Text;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PizzaDelivery.App.ConfigFiles;
using PizzaDelivery.App.DTO;
using PizzaDelivery.App.Interfaces.Tokens;
using PizzaDelivery.Src.Core.Common;


namespace Authorise.Logic;
public class JWTTokenReader : ITokenChecker
{

    private readonly AuthTokenSettings _secrets;
    private readonly HMACSHA256 _encoder;

    public JWTTokenReader(IOptions<AuthTokenSettings> secrets)
    {
        _secrets = secrets.Value;
        _encoder = new HMACSHA256();
    }

    public async Task<Result<AuthTokenUserInfo>> GetCustomerInfoFromToken(string authBearer)
    {
        if(authBearer == null || authBearer.Length == 0)
        {
            return Result.Failure<AuthTokenUserInfo>(new Error("123", "Token empty"));
        }
        var getTokenPayloadResult = readTokenPayload<AuthPayload>(authBearer);

        if(getTokenPayloadResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthTokenUserInfo>(getTokenPayloadResult.ErrorInfo);
        }

        if(IsTokenDead(new NumericDate(getTokenPayloadResult.ResultValue.Explanetion)))
        {
            return Result.Failure<AuthTokenUserInfo>(new Error("123", "Token is dead"));
        }

        return Result.Sucsesfull<AuthTokenUserInfo>(new AuthTokenUserInfo() { CustomerId = getTokenPayloadResult.ResultValue.UserId});

    }
    public async Task<Result> RefreshTokenAlive(string refreshToken)
    {
        if(refreshToken == null || refreshToken.Length == 0)
        {
            return Result.Failure(new Error("123", "Token empty"));
        }

        var getTokenPayloadResult = readTokenPayload<RefreshPayload>(refreshToken);

        if(getTokenPayloadResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthTokenUserInfo>(getTokenPayloadResult.ErrorInfo);
        }

        if(IsTokenDead(new NumericDate(getTokenPayloadResult.ResultValue.Explanetion)))
        {
            return Result.Failure<AuthTokenUserInfo>(new Error("123", "Token is dead"));
        }

        return Result.Sucsesfull();

    }

    private Result<PayloadType> readTokenPayload<PayloadType>(string token)
    {
        if(token is null)
        {
            return Result.Failure<PayloadType>(new Error("1", "input is null"));
        }
        
        var parts = token.Split('.');

        if(parts == null || parts.Length != 3)
        {
            return Result.Failure<PayloadType>(new Error("2", "Token invalid"));
        }

        var checkUnchangingResult = CheckUnchanging(parts);

        if(checkUnchangingResult.IsSucsesfull == false)
        {
            return Result.Failure<PayloadType>(new Error("3", $"TokenInfoWasChange: {checkUnchangingResult.ErrorInfo.Code} - {checkUnchangingResult.ErrorInfo.Message}"));
        }

        var contentResult = readEncodedPayload<PayloadType>(parts[1]);
        
        if(contentResult.IsSucsesfull == false)
        {
            return Result.Failure<PayloadType>(contentResult.ErrorInfo);
        }
        
        var content = contentResult.ResultValue;

        return Result.Sucsesfull<PayloadType>(content);

    }

    private Result<PayloadType> readEncodedPayload<PayloadType>(string payload)
    {
        try{
            var decodedPayload = getDecodedString(payload).Replace("\\\"", "'").Replace("\"", "");

            var type = typeof(PayloadType);
            
            var content = (PayloadType)JsonConvert.DeserializeObject(
                decodedPayload,
                typeof(PayloadType)
                );
            

            if(content is null)
            {
                return Result.Failure<PayloadType>(new Error("123", "Parse error"));
            }

            return Result.Sucsesfull<PayloadType>(content);
        }
        catch (Exception ex)
        {
            return Result.Failure<PayloadType>(new Error("123", ex.Message));
        }
    }
    private string getDecodedString(string encodedString)
    {
        var encodedTextBytes = Convert.FromBase64String(encodedString);
        return Encoding.ASCII.GetString(encodedTextBytes);
    }

    private bool IsJWTToken(string type)
    {
        return type == "JWT";
    }
    private bool HaveAvaliableAlgholitm(string alghoritm)
    {
        return alghoritm == "HS256";
    }

    private Result CheckUnchanging(string[] parts)
    {
        var headerParseResult = readHeaderContent(parts[0]);

        if(headerParseResult.IsSucsesfull == false)
        {
            return Result.Failure(headerParseResult.ErrorInfo);
        }

        var header = headerParseResult.ResultValue;

        if(IsJWTToken(header.Type) == false)
        {
            return Result.Failure(new Error("5", "Is not jwt token"));
        }

        if(HaveAvaliableAlgholitm(header.Algorithm) == false)
        {
            return Result.Failure(new Error("6", "Algholithm not support"));
        }

        var CheckCodeFromToken = parts[2];
        var GeneratedCheckCode = getEncodedStringFromBytes(getSignature(parts[0], parts[1]));

        if(realCodeEqualExpected(GeneratedCheckCode, CheckCodeFromToken) == false)
        {
            return Result.Failure(new Error("123", "CRC changed"));
        }

        return Result.Sucsesfull();
    }

    private bool realCodeEqualExpected(string generatedCode, string expectedCode)
    {
        var compareResult = string.Compare(generatedCode, expectedCode);
        return compareResult == 0;
    }
    private string getEncodedStringFromBytes(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }

    private Result<HeaderContent> readHeaderContent(string encodedHeader)
    {
        try
        {
            var header = getDecodedString(encodedHeader);
            var headerContent = JsonConvert.DeserializeObject<HeaderContent>(header);

            if(headerContent == null)
            {
                return Result.Failure<HeaderContent>(new Error("4", "Header uncurrect"));
            }

            return Result.Sucsesfull<HeaderContent>(headerContent);
        }
        catch (Exception ex)
        {
            return Result.Failure<HeaderContent>(new Error("4", $"Parse error: {ex.Message}"));
        }
        
    }
    private byte[] getSignature(string EncodedHeader, string EncodedPayload)
    {
        return  getEncodedBytesFromString($"{_secrets.JWTSecrets}.{EncodedHeader}.{EncodedPayload}");
    }
    private byte[] getEncodedBytesFromString(string initialData)
    {
        var bytes = Encoding.UTF8.GetBytes(initialData);
        return _encoder.ComputeHash(bytes);
    }

    private bool IsTokenDead(NumericDate tokenEndOfLife)
    {
        return tokenEndOfLife.NumberDate > new NumericDate(DateTime.Now).NumberDate;
    }

    public Task<Result> IsRefreshTokenAlive(string refreshToken)
    {
        throw new NotImplementedException();
    }
}

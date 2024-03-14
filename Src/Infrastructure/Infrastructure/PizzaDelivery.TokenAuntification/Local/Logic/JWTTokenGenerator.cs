using System.Security.Cryptography;
using System.Text;
using ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;
using PizzaDelivery.App.Interfaces;
using PizzaDelivery.App.DTO;
using PizzaDelivery.App.ConfigFiles;
using Microsoft.Extensions.Options;
using PizzaDelivery.Src.Core.Common;
using Newtonsoft.Json;

namespace Authorise.Logic;

public class JWTTokenGenerator : ITokenGenerator
{
    private const string Header = "{'alg': 'HS256','typ': 'JWT'}";

    private readonly AuthTokenSettings _secrets;
    private readonly HMACSHA256 _encoder;

    public JWTTokenGenerator(IOptions<AuthTokenSettings> secrets)
    {
        _secrets = secrets.Value;
        _encoder = new HMACSHA256();
    }

    public AuthBearer Generate(TokenContent content)
    {
        var authTokenLifeTime = DateTime.Now.AddMinutes(_secrets.AuthTokenLifeTime);
        var refreshTokenLifeTime = DateTime.Now.AddMinutes(_secrets.RefreshTokenLifeTime);

        var authPayload = new AuthPayload(){
            UserId = content.CustomerId,
            Issue = _secrets.Issuer,
            IssuedAt = new NumericDate(DateTime.Now).NumberDate,
            Explanetion = new NumericDate(authTokenLifeTime).NumberDate
    };
        var refreshPayload = new RefreshPayload(){
            Issue = _secrets.Issuer,
            IssuedAt = new NumericDate(DateTime.Now).NumberDate,
            RefreshTimeout = new NumericDate(refreshTokenLifeTime).NumberDate,
            NotActiveBefore = new NumericDate(authTokenLifeTime).NumberDate
        };
        var authPayloadJson = getObjectJson(authPayload);
        var refreshPayloadJson = getObjectJson(refreshPayload);
        return new AuthBearer(
            generateTocken(authPayloadJson),
            generateTocken(refreshPayloadJson)
        );
    }
    
    private string generateTocken(string payloadJson)
    {
        var encodedHeader = getEncodedStringFromText(Header);
        var encodedPayload = getEncodedStringFromText(
            getObjectJson(payloadJson)
        );
        var encodedSignature = getEncodedStringFromBytes(
            getSignature(encodedHeader, encodedPayload)
        );
        var authTocken = $"{encodedHeader}.{encodedPayload}.{encodedSignature}";
        return authTocken;
    }
    private string getEncodedStringFromText(string Json)
    {
        var plainTextBypes = Encoding.UTF8.GetBytes(Json);
        return Convert.ToBase64String(plainTextBypes);
    }
    private string getEncodedStringFromBytes(byte[] bytes)
    {
        return Convert.ToBase64String(bytes);
    }
    private string getObjectJson(object Payload)
    {
        return JsonConvert.SerializeObject(Payload);
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
}

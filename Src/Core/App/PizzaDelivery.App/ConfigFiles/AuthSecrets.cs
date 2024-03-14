using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.App.ConfigFiles;

public class AuthTokenSettings
{
    public string Issuer { get; init; }
    public string JWTSecrets { get; init; }
    public string EncriptionKey { get; init; }

    public int AuthTokenLifeTime { get; init; }
    public int RefreshTokenLifeTime { get; init; }
}

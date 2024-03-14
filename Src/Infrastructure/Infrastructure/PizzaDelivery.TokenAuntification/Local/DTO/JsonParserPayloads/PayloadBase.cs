using System.Text.Json.Serialization;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

public class PayloadBase
{
    [JsonPropertyName("iss")]
    public string Issue {get; init; }
    [JsonPropertyName("exp")]
    public long Explanetion { get; init; } // numericDate
    [JsonPropertyName("iat")]
    public long IssuedAt { get; init; }// numericDate

}

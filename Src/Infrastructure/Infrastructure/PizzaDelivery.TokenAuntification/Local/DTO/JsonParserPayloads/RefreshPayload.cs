using System.Text.Json.Serialization;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

public class RefreshPayload : PayloadBase
{
    [JsonPropertyName("nbf")]
    public long NotActiveBefore { get; init; } // numericDate
    [JsonPropertyName("ref")]
    public long RefreshTimeout {get;init;}

}

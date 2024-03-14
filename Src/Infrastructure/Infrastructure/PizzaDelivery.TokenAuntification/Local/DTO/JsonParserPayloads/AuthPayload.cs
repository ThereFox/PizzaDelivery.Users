using System.Text.Json.Serialization;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

public class AuthPayload : PayloadBase
{
    [JsonPropertyName("id")]
    public Guid UserId { get; init; }

}

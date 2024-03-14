using System.Text.Json.Serialization;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.Bearer.Payload;

public class HeaderContent
{
    [JsonPropertyName("alg")]
    [JsonInclude]
    public string Algorithm { get; set; }
    [JsonPropertyName("typ")]
    [JsonInclude]
    public string Type { get; set; }

    [JsonConstructor]
    public HeaderContent(string alg, string typ) 
    {
        Algorithm = alg;
        Type = typ;
    }
}


using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Classification
{
    protected Classification() 
    {
        Type = string.Empty;
        Subtype = string.Empty;
        ConcreteQuality = string.Empty;
        Standard = string.Empty;
        Revision = string.Empty;
    }

    public Classification(string main, string concreteQuality)
    {
        Type = main;
        Subtype = string.Empty;
        ConcreteQuality = concreteQuality;
        Standard = string.Empty;
        Revision = string.Empty;
    }
    
    public Classification(string main, string subtype, string concreteQuality)
    {
        Type = main;
        Subtype = subtype;
        ConcreteQuality = concreteQuality;
        Standard = string.Empty;
        Revision = string.Empty;
    }

    [JsonPropertyName("type")]
    public string Type { get; protected set; }

    [JsonPropertyName("subType")]
    public string Subtype { get; protected set; }

    [JsonPropertyName("concreteQuality")]
    public string ConcreteQuality { get; protected set; }

    [JsonPropertyName("standard")]
    public string Standard {  get; protected set; }

    [JsonPropertyName("revision")]
    public string Revision { get; protected set; }

    public void SetStandard(string standard)
    {
        Standard = standard;
    }

    public void SetRevision(string revision)
    {
        Revision = revision;
    }
}
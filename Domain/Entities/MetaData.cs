using System.Text.Json.Serialization;

namespace Domain.Entities;

public class MetaData
{
    [JsonPropertyName("createdBy")]
    public string CreatedBy { get; set; } = string.Empty;
    
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("lastModified")]
    public DateTime LastModified { get; set; }
    
    [JsonPropertyName("author")]
    public string Author { get; set; } = string.Empty;
}
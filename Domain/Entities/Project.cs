
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Project
{
    [JsonPropertyName("projectId")]
    public string ProjectId { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("street")]
    public string Street { get; set; } = string.Empty;
    
    [JsonPropertyName("postalcode")]
    public string Postalcode { get; set; } = string.Empty;

    [JsonPropertyName("city")] 
    public string City { get; set; } = string.Empty;
    
    [JsonPropertyName("building")]
    public string Building { get; set; } = string.Empty;

    [JsonPropertyName("floor")]
    public string Floor { get; set; } = string.Empty;
}
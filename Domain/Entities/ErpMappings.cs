using System.Text.Json.Serialization;

namespace Domain.Entities;

public class ErpMappings
{
    [JsonConstructor]
    public ErpMappings() { }

    public ErpMappings(string articleNumber, string costCenter, double amout, string unit)
    {
        ArticleNumber = articleNumber;
        CostCenter = costCenter;
        Amount = amout;
        Unit = unit;
    }

    [JsonPropertyName("articleNumber")]
    public string ArticleNumber { get; set; }

    [JsonPropertyName("costCenter")]
    public string CostCenter { get; set; }

    [JsonPropertyName("amount")]
    public double Amount  { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }
}
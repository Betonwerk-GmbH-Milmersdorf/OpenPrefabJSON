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

    public string ArticleNumber { get; set; }
  	public string CostCenter { get; set; }
	public double Amount  { get; set; }
    public string Unit { get; set; }
}
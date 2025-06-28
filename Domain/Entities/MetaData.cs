
namespace Domain.Entities;

public class MetaData
{
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
    public DateTime LastModified { get; set; }
  	public string Author { get; set; } = string.Empty;
}
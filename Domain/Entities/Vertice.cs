
namespace Domain.Entities;

public class Vertice(string id, double x, double y, double z)
{
    public string ID { get; set; } = id;
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;
}
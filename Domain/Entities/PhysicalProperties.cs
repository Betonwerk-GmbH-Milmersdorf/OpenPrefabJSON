using System.Text.Json.Serialization;

namespace Domain.Entities;

public class PhysicalProperties
{
    [JsonConstructor]
    public PhysicalProperties() { }

    public PhysicalProperties(
        double length, 
        double width, 
        double heigth,
        double volumen,
        double weight)
    {
        Length = length;
        Width = width;
        Height = heigth;
        Volume = volumen;
        Weight = weight;
    }

    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Volume { get; set; }
    public double Weight { get; set; }
}
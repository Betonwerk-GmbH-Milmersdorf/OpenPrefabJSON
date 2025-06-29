
namespace Domain.Entities;

public class Geometry(List<Vertice> vertices, List<Edge> edges, List<Face> faces)
{
    public List<Vertice> Vertices { get; set; } = vertices;
    public List<Edge> Edges { get; set; } = edges;
    public List<Face> Faces { get; set; } = faces;
}
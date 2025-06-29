
namespace Domain.Entities;

public class Face(string id, List<string> edgeLoop, NormalVector normal)
{
    public string ID { get; set; } = id;
    public List<string> EdgeLoop { get; set; } = edgeLoop;
    public NormalVector Normal { get; set; } = normal;
}
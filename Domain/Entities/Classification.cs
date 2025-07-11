
namespace Domain.Entities;

public class Classification
{
    protected Classification() 
    {
        Main = string.Empty;
        Subtype = string.Empty;
        ConcreteQuality = string.Empty;
        Standard = string.Empty;
        Revision = string.Empty;
    }

    public Classification(string main, string concreteQuality)
    {
        Main = main;
        Subtype = string.Empty;
        ConcreteQuality = concreteQuality;
        Standard = string.Empty;
        Revision = string.Empty;
    }
    
    public Classification(string main, string subtype, string concreteQuality)
    {
        Main = main;
        Subtype = subtype;
        ConcreteQuality = concreteQuality;
        Standard = string.Empty;
        Revision = string.Empty;
    }

    public string Main { get; protected set; }
    public string Subtype { get; protected set; }    
    public string ConcreteQuality { get; protected set; }
    public string Standard {  get; protected set; }
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
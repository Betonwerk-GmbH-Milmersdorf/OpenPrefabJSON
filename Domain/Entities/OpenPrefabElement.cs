using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OpenPrefabElement
{
    [JsonConstructor]
    protected OpenPrefabElement()
    {
        ElementId = Guid.NewGuid();
        
        CustomAttributes = [];

        MetaData = new()
        {
            CreatedBy = string.Empty,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
            Author = string.Empty
        };
    }

    #region Props
    public static string Format =>  "OpenPrefabJSON";
    public double Version { get; set; } = 0.1;
    public Guid ElementId { get; set; }
    public string Description { get; set; } = string.Empty;
    public ElementType ElementType { get; set; }
    public PhysicalProperties PhysicalProperties { get; set; }
    public Project Project { get; set; }
    public ErpMappings ErpMappings { get; set; }
    public Dictionary<string, object> CustomAttributes { get; protected set; }
    public MetaData? MetaData { get; set; }
    #endregion

    public static OpenPrefabElement Create(
        string description,
        PhysicalProperties physicalProperties,
        Project project,
        ElementType elementType,
        ErpMappings mappings,
        string creatingSoftware,
        string author)
    {
        MetaData metaData = new()
        {
            CreatedBy = creatingSoftware,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
            Author = author
        };

        return new OpenPrefabElement()
        {
            Description = description,
            PhysicalProperties = physicalProperties,
            Project = project,
            ElementId = Guid.NewGuid(),
            ElementType = elementType,
            ErpMappings = mappings,
            MetaData = metaData
        };
    }
}
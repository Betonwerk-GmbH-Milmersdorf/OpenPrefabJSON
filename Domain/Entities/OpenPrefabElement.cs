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
    [JsonPropertyName("format")]
    public string Format =>  "OpenPrefabJSON";
    
    [JsonPropertyName("version")]
    public string Version { get; set; } = "0.1";
    
    [JsonPropertyName("elementId")]
    public Guid ElementId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("classification")]
    public Classification Classification { get; set; }

    [JsonPropertyName("physicalProperties")]
    public PhysicalProperties PhysicalProperties { get; set; }

    [JsonPropertyName("project")]
    public Project Project { get; set; }

    [JsonPropertyName("erpMappings")]
    public ErpMappings ErpMappings { get; set; }
    
    [JsonPropertyName("customAttributes")]
    public Dictionary<string, object> CustomAttributes { get; protected set; }

    [JsonPropertyName("metaData")]
    public MetaData MetaData { get; set; }
    #endregion

    public static OpenPrefabElement Create(
        string description,
        PhysicalProperties physicalProperties,
        Project project,
        Classification elementType,
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
            Classification = elementType,
            ErpMappings = mappings,
            MetaData = metaData
        };
    }
}
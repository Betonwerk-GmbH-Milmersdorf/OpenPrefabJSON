using Json.Schema;
using System.Text.Json;

namespace Tests;

public class JsonTests
{
    [Fact]
    public void ShouldSerializeConcreteElementWithEmbeddedParts()
    {
        var embeddedParts = new[]
        {
            new Dictionary<string, object>
            {
                { "articleNumber", "ZUB-30420" },
                { "description", "Hülse für Geländeranschluss" },
                { "quantity", 4 },
                { "unit", "Stück" }
            },
            new Dictionary<string, object>
            {
                { "articleNumber", "ZUB-50012" },
                { "description", "Leerrohr für Elektrik" },
                { "quantity", 2.5 },
                { "unit", "m" }
            }
        };

        var element = new
        {
            id = Guid.NewGuid(),
            type = new
            {
                main = "Slab",
                subtype = "HollowCoreSlab"
            },
            erpMappings = new
            {
                articleNumber = "SL-2025-041",
                costCenter = "Fertigung Süd",
                workflowStep = "Bewehrung abgeschlossen",
                linkedBillOfMaterials = new[] { "RZ12", "ST12" }
            },
            embeddedParts = embeddedParts,
            customAttributes = new Dictionary<string, object>
                {
                    { "Brandschutzklasse", "F30" },
                    { "Oberflächenversiegelung", "Hydrophobierung" }
                },
            createdAt = DateTime.UtcNow
        };

        var json = JsonSerializer.Serialize(element, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        Assert.Contains("HollowCoreSlab", json);
        Assert.Contains("ZUB-30420", json);
        Assert.Contains("customAttributes", json);
        Assert.DoesNotContain("error", json, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async void ConcreteElement_ShouldMatchOpenPrefabJsonSchema()
    {
        var embeddedParts = new[]
        {
            new Dictionary<string, object>
            {
                { "articleNumber", "ZUB-30420" },
                { "description", "Hülse für Geländeranschluss" },
                { "quantity", 4 },
                { "unit", "Stück" }
            },
            new Dictionary<string, object>
            {
                { "articleNumber", "ZUB-50012" },
                { "description", "Leerrohr für Elektrik" },
                { "quantity", 2.5 },
                { "unit", "m" }
            }
        };

        var element = new
        {
            id = Guid.NewGuid(),
            type = new
            {
                main = "Slab",
                subtype = "HollowCoreSlab"
            },
            erpMappings = new
            {
                articleNumber = "SL-2025-041",
                costCenter = "Fertigung Süd",
                workflowStep = "Bewehrung abgeschlossen",
                linkedBillOfMaterials = new[] { "RZ12", "ST12" }
            },
            embeddedParts = embeddedParts,
            customAttributes = new Dictionary<string, object>
                {
                    { "Brandschutzklasse", "F30" },
                    { "Oberflächenversiegelung", "Hydrophobierung" }
                },
            createdAt = DateTime.UtcNow
        };

        // JSON serialisieren
        var node = JsonSerializer.SerializeToNode(element);

        // Schema von GitHub laden
        using var http = new HttpClient();
        var schemaText = await http.GetStringAsync("https://raw.githubusercontent.com/Betonwerk-GmbH-Milmersdorf/OpenPrefabJSON/master/Schema/openprefab.schema.json");
        var schema = JsonSchema.FromText(schemaText);

        // Validierung
        var result = schema.Evaluate(node);

        // Ergebnis prüfen
        Assert.True(result.IsValid, $"Schema validation failed:\n{result.Errors}");
    }
}

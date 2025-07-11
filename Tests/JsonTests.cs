using Domain.Entities;
using Json.Schema;
using System.Diagnostics;
using System.Text.Json;
using Xunit.Abstractions;

namespace Tests;

public class JsonTests(ITestOutputHelper output)
{
    private readonly ITestOutputHelper _output = output;

    [Fact]
    public async void ConcreteElement_ShouldMatchOpenPrefabJsonSchema()
    {
        string description = "FT Sturz";

        PhysicalProperties physicalProperties = new()
        {
            Length = 3,
            Width = 0.5,
            Height = 0.2,
            Volume = 3 * 0.5 * 0.2,
            Weight = 3 * 0.5 * 0.2 * 2.5
        };

        Project project = new()
        {
            ProjectId = "123456",
            Name = "EFH Test",
            Street = "Teststraße 1",
            Postalcode = "10118",
            City = "Berlin",
            Building = "Haus 1",
            Floor = "EG"
        };

        Classification classification = new("Stair", "C40/50");

        ErpMappings erpMappings = new()
        {
            ArticleNumber = "10000",
            CostCenter = "1122",
            Amount = 3,
            Unit = "m"
        };

        var element = OpenPrefabElement.Create(
            description,
            physicalProperties,
            project,
            classification,
            erpMappings,
            "OpenPrefabJsonTest",
            "TestAuthor");

        // JSON serialisieren
        string jsonString = JsonSerializer.Serialize(element);
        using var jsonDoc = JsonDocument.Parse(jsonString);

        // Schema von GitHub laden
        using var http = new HttpClient();
        var schemaText = await http.GetStringAsync("https://raw.githubusercontent.com/Betonwerk-GmbH-Milmersdorf/OpenPrefabJSON/master/Schema/openprefab.schema.json");
        var schema = JsonSchema.FromText(schemaText);

        var result = schema.Evaluate(jsonDoc.RootElement, new EvaluationOptions
        {
            OutputFormat = OutputFormat.Hierarchical,
            RequireFormatValidation = true
        });

        if (!result.IsValid)
        {
            var errorJson = JsonSerializer.Serialize(result.Details, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            //// → xUnit-konforme Ausgabe
            //_output.WriteLine("Schema validation failed:\n" + errorJson);

            _output.WriteLine("VALIDATION ERROR:");
            _output.WriteLine(errorJson);
        }

        Assert.True(result.IsValid, "JSON entspricht nicht dem Schema.");
    }
}

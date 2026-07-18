using BinaryKits.Zpl.Viewer;
using System.Text.Json;

namespace ZplRenderer.Core;

public static class Parser
{
    public static string Analyze(string zpl)
    {
        var printerStorage = new PrinterStorage();

        var analyzer = new ZplAnalyzer(printerStorage);

        var result = analyzer.Analyze(zpl);

        return JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}
using BinaryKits.Zpl.Viewer;
using BinaryKits.Zpl.Viewer.Models;
using System.Text.Json;

namespace ZplRenderer.Core;

public static class Parser
{
    public static AnalyzeInfo Parse(string zpl)
    {
        return Parse(zpl, new PrinterStorage());
    }

    internal static AnalyzeInfo Parse(
        string zpl,
        PrinterStorage printerStorage)
    {
        var analyzer = new ZplAnalyzer(printerStorage);

        return analyzer.Analyze(zpl);
    }

    public static string Analyze(string zpl)
    {
        var result = Parse(zpl);

        return JsonSerializer.Serialize(
            result,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
    }
}
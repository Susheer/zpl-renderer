using System.Text.Json;
using BinaryKits.Zpl.Viewer.Models;

namespace ZplRenderer.Core;

internal static class Json
{
    internal static string Serialize(AnalyzeInfo value)
    {
        return JsonSerializer.Serialize(
            value,
            JsonContext.Default.AnalyzeInfo);
    }

    internal static RenderOptions DeserializeRenderOptions(string json)
    {
        return JsonSerializer.Deserialize(
                   json,
                   JsonContext.Default.RenderOptions)
               ?? new RenderOptions();
    }
}
using System.Text.Json;

namespace ZplRenderer.Core;

internal static class Json
{
    internal static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

    internal static string Serialize(object value)
    {
        return JsonSerializer.Serialize(value, Options);
    }
}
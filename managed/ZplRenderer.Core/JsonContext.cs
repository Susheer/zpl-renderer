using System.Text.Json.Serialization;
using BinaryKits.Zpl.Viewer.Models;

namespace ZplRenderer.Core;

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(AnalyzeInfo))]
internal partial class JsonContext : JsonSerializerContext
{
}
using System.Text.Json.Serialization;

namespace ZplRenderer.Core;

[JsonSerializable(typeof(RenderOptions))]
[JsonSerializable(typeof(BinaryKits.Zpl.Viewer.Models.AnalyzeInfo))]
internal partial class JsonContext : JsonSerializerContext
{
}
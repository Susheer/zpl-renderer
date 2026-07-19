namespace ZplRenderer.Core;

public sealed class RenderOptions
{
    public double LabelWidth { get; set; } = 101.6;

    public double LabelHeight { get; set; } = 152.4;

    public int PrintDensityDpmm { get; set; } = 8;

    public bool OpaqueBackground { get; set; } = true;
}
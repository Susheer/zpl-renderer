using BinaryKits.Zpl.Viewer;
namespace ZplRenderer.Core;
using BinaryKits.Zpl.Viewer.ElementDrawers;

public static class Renderer
{
    public static byte[] RenderPng(string zpl, RenderOptions options)
    {
        var printerStorage = new PrinterStorage();

        var result = Parser.Parse(zpl, printerStorage);

        if (result.LabelInfos.Length == 0)
            throw new InvalidOperationException("No labels found.");
        
        var drawer = new ZplElementDrawer(printerStorage, new DrawerOptions
        {
            OpaqueBackground = options.OpaqueBackground
        });

        return drawer.Draw(
        result.LabelInfos[0].ZplElements,
        options.LabelWidth,
        options.LabelHeight,
        options.PrintDensityDpmm);
    }
}
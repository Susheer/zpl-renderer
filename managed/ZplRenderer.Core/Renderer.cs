using BinaryKits.Zpl.Viewer;

namespace ZplRenderer.Core;

public static class Renderer
{
    public static byte[] RenderPng(string zpl)
    {
        var printerStorage = new PrinterStorage();

        var result = Parser.Parse(zpl, printerStorage);

        if (result.LabelInfos.Length == 0)
            throw new InvalidOperationException("No labels found.");

        var drawer = new ZplElementDrawer(printerStorage);

        return drawer.Draw(result.LabelInfos[0].ZplElements);
    }
}
using System.IO;
using ZplRenderer.Core;

string zpl =
"""
^XA
^FO50,50
^A0N,40,40
^FDHello World^FS
^XZ
""";

Console.WriteLine("Rendering...");

var png = Renderer.RenderPng(zpl);

File.WriteAllBytes("label.png", png);

Console.WriteLine($"Generated {png.Length} bytes");
Console.WriteLine("Saved label.png");
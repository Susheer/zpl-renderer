using ZplRenderer.Core;

string zpl =
"""
^XA
^FO50,50
^A0N,40,40
^FDHello World^FS
^XZ
""";

Console.WriteLine("Parsing...");

string json = Parser.Analyze(zpl);

Console.WriteLine(json);
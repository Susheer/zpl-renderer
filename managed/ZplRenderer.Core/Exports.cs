using System;
using System.Runtime.InteropServices;

namespace ZplRenderer.Core;

public static class Exports
{
    [UnmanagedCallersOnly(EntryPoint = "Initialize")]
    public static int Initialize()
    {
        return 1;
    }

    [UnmanagedCallersOnly(EntryPoint = "GetVersion")]
    public static IntPtr GetVersion()
    {
        return Memory.AllocString("0.2.0");
    }

    [UnmanagedCallersOnly(EntryPoint = "Parse")]
    public static IntPtr Parse(IntPtr utf8)
    {
        var zpl = Marshal.PtrToStringUTF8(utf8) ?? string.Empty;

        var json = Parser.Analyze(zpl);

        return Memory.AllocString(json);
    }

    [UnmanagedCallersOnly(EntryPoint = "FreeMemory")]
    public static void FreeMemory(IntPtr ptr)
    {
        Memory.Free(ptr);
    }
}
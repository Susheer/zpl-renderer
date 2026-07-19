using System;
using System.Runtime.InteropServices;
using System.Text.Json;

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
        return Memory.AllocString("0.3.0");
    }

    [UnmanagedCallersOnly(EntryPoint = "Parse")]
    public static IntPtr Parse(IntPtr utf8)
    {
        var zpl = Marshal.PtrToStringUTF8(utf8) ?? string.Empty;

        var json = Parser.Analyze(zpl);

        return Memory.AllocString(json);
    }

    [UnmanagedCallersOnly(EntryPoint = "RenderPng")]
    public static unsafe IntPtr RenderPng(IntPtr zplPtr, IntPtr optionsPtr, int* length)
    {
        var zpl = Marshal.PtrToStringUTF8(zplPtr) ?? string.Empty;
        var json = Marshal.PtrToStringUTF8(optionsPtr);
       var options = string.IsNullOrWhiteSpace(json)
    ? new RenderOptions()
    : Json.DeserializeRenderOptions(json);
        var png = Renderer.RenderPng(zpl, options);

        *length = png.Length;

        return Memory.AllocBytes(png);
    }

    [UnmanagedCallersOnly(EntryPoint = "FreeMemory")]
    public static void FreeMemory(IntPtr ptr)
    {
        Memory.Free(ptr);
    }
}
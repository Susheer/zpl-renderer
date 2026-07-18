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
        return Memory.AllocUtf8("0.1.0");
    }

    [UnmanagedCallersOnly(EntryPoint = "FreeMemory")]
    public static void FreeMemory(IntPtr ptr)
    {
        Memory.Free(ptr);
    }
}
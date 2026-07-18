using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ZplRenderer.Core;

internal static class Memory
{
    internal static IntPtr AllocString(string value)
    {
        if (string.IsNullOrEmpty(value))
            return IntPtr.Zero;

        byte[] bytes = Encoding.UTF8.GetBytes(value + '\0');

        IntPtr ptr = Marshal.AllocCoTaskMem(bytes.Length);

        Marshal.Copy(bytes, 0, ptr, bytes.Length);

        return ptr;
    }

    internal static IntPtr AllocBytes(byte[] bytes)
    {
        if (bytes == null || bytes.Length == 0)
            return IntPtr.Zero;

        IntPtr ptr = Marshal.AllocCoTaskMem(bytes.Length);

        Marshal.Copy(bytes, 0, ptr, bytes.Length);

        return ptr;
    }

    internal static void Free(IntPtr ptr)
    {
        if (ptr != IntPtr.Zero)
        {
            Marshal.FreeCoTaskMem(ptr);
        }
    }
}
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ZplRenderer.Core;

internal static class Memory
{
    public static IntPtr AllocUtf8(string text)
    {
        if (text == null)
            return IntPtr.Zero;

        byte[] bytes = Encoding.UTF8.GetBytes(text + '\0');

        IntPtr ptr = Marshal.AllocCoTaskMem(bytes.Length);

        Marshal.Copy(bytes, 0, ptr, bytes.Length);

        return ptr;
    }

    public static void Free(IntPtr ptr)
    {
        if (ptr != IntPtr.Zero)
            Marshal.FreeCoTaskMem(ptr);
    }
}
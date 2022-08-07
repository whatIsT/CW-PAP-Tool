using System;
using System.Runtime.InteropServices;

namespace MemClass
{
    internal class DllImports
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory
            (
                int hProcess,
                long lpBaseAddress,
                byte[] lpBuffer,
                int nSize,
                out int lpNumberOfBytesRead
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory
            (
                int hProcess,
                long lpBaseAddress,
                byte[] lpBuffer,
                int dwSize,
                out int lpNumberOfBytesWritten
            );

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess
            (
                int dwDesiredAccess,
                bool bInheritHandle,
                int dwProcessId
            );
    }
}

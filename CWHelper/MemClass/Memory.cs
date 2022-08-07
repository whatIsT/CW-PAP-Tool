using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace MemClass
{
    /// <summary>
    /// Yoinked most of this shit from a couple repositories/StackOverflow but I made a couple modifications to suit my liking
    /// </summary>
    public class Memory
    {
        const int ProcessVMWrite = 0x0020;
        const int ProcessVMOperation = 0x0008;

        private static Process proc;

        public Memory(string game)
        {
            proc = Process.GetProcessesByName(game).FirstOrDefault();
        }

        public long BaseAddress { get { return (long)proc.MainModule.BaseAddress; } }
        private int handleWrite { get { return (int)DllImports.OpenProcess(ProcessVMOperation | ProcessVMWrite, false, proc.Id); } }
        private int handleRead { get { return (int)proc.Handle; } }

        #region write
        public void WriteBytes(long address, byte[] bytes)
        {
            if (!DllImports.WriteProcessMemory(handleWrite, address, bytes, bytes.Length, out _))
            {
                throw new ArgumentException(new Win32Exception(Marshal.GetLastWin32Error()).Message);
            }
        }

        public void Write<T>(long address, T value)
        {
            int size = Marshal.SizeOf<T>();
            byte[] result = new byte[size];
            GCHandle gcHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
            Marshal.Copy(gcHandle.AddrOfPinnedObject(), result, 0, size);
            gcHandle.Free();
            WriteBytes(address, result);
        }
        #endregion

        #region read
        public byte[] ReadBytes(long address, int size)
        {
            byte[] bytes = new byte[size];
            if (!DllImports.ReadProcessMemory(handleRead, address, bytes, bytes.Length, out _))
            {
                throw new ArgumentException(new Win32Exception(Marshal.GetLastWin32Error()).Message);
            }
            return bytes;
        }

        public T Read<T>(long address)
        {
            byte[] data = ReadBytes(address, Marshal.SizeOf<T>());
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        public long[] FindBytes(string sig, long startAddress, long endAddress, bool firstMatch = false, int bufferSize = 0xFFFF)
        {
            string[] array = sig.Split(' ');
            byte?[] needle = new byte?[array.Length];
            for (int i = 0; i < needle.Length; i++)
            {
                if (array[i] == "?" || array[i] == "??")
                    needle[i] = null;
                else
                    needle[i] = byte.Parse(array[i], System.Globalization.NumberStyles.HexNumber);
            }

            List<long> results = new List<long>();
            long searchAddress = startAddress;

            int needleIndex = 0;
            int bufferIndex = 0;

            while (true)
            {
                try
                {
                    byte[] buffer = ReadBytes(searchAddress, bufferSize);

                    for (bufferIndex = 0; bufferIndex < buffer.Length; bufferIndex++)
                    {
                        if (needle[needleIndex] == null)
                        {
                            needleIndex++;
                            continue;
                        }

                        if (needle[needleIndex] == buffer[bufferIndex])
                        {
                            needleIndex++;

                            if (needleIndex == needle.Length)
                            {
                                results.Add(searchAddress + bufferIndex - needle.Length + 1);

                                if (firstMatch)
                                    return results.ToArray();

                                needleIndex = 0;
                            }
                        }
                        else
                        {
                            needleIndex = 0;
                        }
                    }
                }
                catch
                {
                    break;
                }

                searchAddress += bufferSize;

                if (searchAddress > endAddress)
                    break;
            }

            if (results.Count == 0)
                results.Add(0); // Prevent errors
            return results.ToArray();
        }
        #endregion
    }
}

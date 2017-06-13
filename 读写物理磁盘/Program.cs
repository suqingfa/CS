using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace 读写物理磁盘
{
    class Program
    {
        [DllImport("kernel32", SetLastError = true)]
        static extern SafeFileHandle CreateFile(
            string FileName,
            uint DesiredAccess,
            uint ShareMode,
            IntPtr SecurityAttributes,
            uint CreationDisposition,
            uint FlagsAndAttributes,
            IntPtr hTemplate
        );

        static void Main(string[] args)
        {
            var hFile = CreateFile(
                @"\\.\PhysicalDrive1",
                0x80000000,                 // GENERIC_READ
                0x00000001 | 0x00000002,    //  FILE_SHARE_WRITE | FILE_SHARE_READ,
                IntPtr.Zero,
                3,                          // OPEN_EXISTING
                0,
                IntPtr.Zero);

            if (hFile.IsInvalid)
            {
                Console.WriteLine("Open Fail");
                return;
            }

            var stream = new FileStream(hFile, FileAccess.Read);

            var buffer = new byte[512];
            stream.Read(buffer, 0, buffer.Length);

            for (int i = 0; i < buffer.Length; i++)
            {
                Console.Write("{0:X2} ", buffer[i]);
                if (i % 16 == 15)
                    Console.WriteLine();
            }
        }
    }
}

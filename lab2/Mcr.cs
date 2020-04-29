
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace Mñr_lib
{
    class Mcr
    {

        public const int MAX_WORD_LEN = 32;
        public const int MAX_WORD_COUNT = 200;

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct Tinlex
        {

            /// char[32]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 32)]
            public string anword;

            /// unsigned char
            public byte cid;

            /// unsigned char
            public byte vid;

            /// char
            public byte virt;

            /// unsigned char
            public byte para;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Tinlexdata
        {

            /// Tinlex[200]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = System.Runtime.InteropServices.UnmanagedType.Struct)]
            public Tinlex[] inlex;

            /// int
            public int count;
        }


        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Tid
        {

            /// unsigned int
            public uint lnk;

            /// unsigned char
            public byte en;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Tids
        {

            /// Tid[200]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = System.Runtime.InteropServices.UnmanagedType.Struct)]
            public Tid[] ids;

            /// int
            public int count;
        }


        [DllImport("mcr.dll", CharSet = CharSet.None, CallingConvention = CallingConvention.Cdecl)]
        public static extern int InitMcr();

        [DllImport("mcr.dll", CharSet = CharSet.None, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LoadMcr([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string s);

        [DllImport("mcr.dll", CharSet = CharSet.None)]
        public static extern int SaveMcr([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string s);

        [DllImport("mcr.dll", CharSet = CharSet.None, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FindWID([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string s, ref Tids ids);

        [DllImport("mcr.dll", CharSet = CharSet.None, EntryPoint = "GetWordById", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetWordById(Tid id, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool gh_only, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool all, ref Tinlexdata outdata);

        [DllImport("mcr.dll", CharSet = CharSet.None)]
        public static extern bool ReadOnlyDict();

        [DllImport("mcr.dll", CharSet = CharSet.None)]
        public static extern int AddParadigma(ref Tinlexdata indata);

        [DllImport("mcr.dll", CharSet = CharSet.None)]
        public static extern int FreeSpace(System.IntPtr ar1, System.IntPtr ar2, System.IntPtr ar3);

        [DllImport("mcr.dll", CharSet = CharSet.None)]
        public static extern int Ver(System.IntPtr s);

        [DllImport("mcr.dll", CharSet = CharSet.None, CallingConvention = CallingConvention.Cdecl)]
        public static extern string ConstIdToStr(byte cid);

        [DllImport("mcr.dll", CharSet = CharSet.None, CallingConvention = CallingConvention.Cdecl)]
        public static extern string VarIdToStr(byte cid, byte vid);

        [DllImport("mcr.dll", CharSet = CharSet.None, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetBGH(int lnk, byte const_gh, byte var_gh, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool all, ref Tinlexdata outdata);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace UnixDirectoryFormatting
{
    class Program
    {
        //PInvoke references to allow us to set the clipboard
        [DllImport("user32.dll")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        internal static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        internal static extern bool SetClipboardData(uint uFormat, IntPtr data);

        const int CF_UNICODETEXT = 13;

        [STAThread]
        static void Main(string[] args)
        {
           // if an argument has been passed to the app
            if(args.Length >0)
            {
                OpenClipboard(IntPtr.Zero);
                
                string dosPath = args[0]; // get the dos path
                string unixPath = dosPath.Replace('\\','/'); // replace the dos slash with the unix one.

                var ptr = Marshal.StringToHGlobalUni(unixPath);// put it in a pointer for use in the pinvoke call

                SetClipboardData(CF_UNICODETEXT, ptr);// set the clipboard text

                CloseClipboard();

                Marshal.FreeHGlobal(ptr);//free the pointer.
            }
        }
    }
}

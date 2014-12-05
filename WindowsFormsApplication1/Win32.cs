using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;

using System.Runtime.InteropServices;

namespace Lync
{
    sealed class Win32
    {

      #region PixelDLL && Methods
        [DllImport("user32.dll")]
      static extern IntPtr GetDC(IntPtr hwnd);

      [DllImport("user32.dll")]
      static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

      [DllImport("gdi32.dll")]
      static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

      static public Color GetPixelColor(int x, int y)
      {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                                        (int)(pixel & 0x0000FF00) >> 8,
                                        (int)(pixel & 0x00FF0000) >> 16);
            return color;
      }
        #endregion


      #region Global Keyboard Hooks

      [DllImport("user32.dll")]
      static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

      [DllImport("user32.dll")]
      static extern bool UnhookWindowsHookEx(IntPtr hInstance);

      [DllImport("user32.dll")]
      static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

      [DllImport("kernel32.dll")]
      static extern IntPtr LoadLibrary(string lpFileName);

      private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

      const int WH_KEYBOARD_LL = 13;
      const int WM_KEYDOWN = 0x100;

      private static LowLevelKeyboardProc _proc = hookProc;

      private static IntPtr hhook = IntPtr.Zero;

      public static void SetHook()
      {
          IntPtr hInstance = LoadLibrary("User32");
          hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
      }

      public static void UnHook()
      {
          UnhookWindowsHookEx(hhook);
      }

      public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
      {
          if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
          {
              int vkCode = Marshal.ReadInt32(lParam);
              if (vkCode.ToString() == "13")
              {
                  Operaciones.AutoRemo();              
              }
              return (IntPtr)1;
          }
          else
              return CallNextHookEx(hhook, code, (int)wParam, lParam);
      }

      #endregion


      

    }
}

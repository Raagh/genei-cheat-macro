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
using System.Diagnostics;

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

      // NO SE USA AL FINAL
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
          hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc2, hInstance, 0);
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
              if (vkCode.ToString() == Config.TeclaRemo)
              {
                  Operaciones.AutoRemo();              
              }
              if (vkCode.ToString() == Config.TeclaInvi)
              {
                  Operaciones.AutoInvi();
              }
              if ((Keys)vkCode == Keys.F5)
              {
                  Win32.UnHook();
                  Application.Exit();
              }
              return (IntPtr)1;
          }
          else
              return CallNextHookEx(hhook, code, (int)wParam, lParam);
      }

      #endregion        


      #region Global Mouse Hooks

      [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

      [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool UnhookWindowsHookExMouse(IntPtr hhk);

      [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
          IntPtr wParam, IntPtr lParam);

      [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern IntPtr GetModuleHandle(string lpModuleName);


      public static LowLevelMouseProc _proc2 = HookCallback;
      public static IntPtr _hookID = IntPtr.Zero;

      public static void unHookMouse()
      {
          UnhookWindowsHookExMouse(_hookID);     
      }


      public static IntPtr SetHook(LowLevelMouseProc proc)
      {
          using (Process curProcess = Process.GetCurrentProcess())
          using (ProcessModule curModule = curProcess.MainModule)
          {
              return SetWindowsHookEx(WH_MOUSE_LL, proc,
                  GetModuleHandle(curModule.ModuleName), 0);
          }
      }

      public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

      private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
      {
          if (nCode >= 0 && MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
          {
              MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
              Operaciones.AutoLanzar();
          }
          return CallNextHookEx(_hookID, nCode, wParam, lParam);
      }

      private const int WH_MOUSE_LL = 14;

      private enum MouseMessages
      {
          WM_LBUTTONDOWN = 0x0201,
          WM_LBUTTONUP = 0x0202,
          WM_MOUSEMOVE = 0x0200,
          WM_MOUSEWHEEL = 0x020A,
          WM_RBUTTONDOWN = 0x0204,
          WM_RBUTTONUP = 0x0205
      }

      [StructLayout(LayoutKind.Sequential)]
      private struct POINT
      {
          public int x;
          public int y;
      }

      [StructLayout(LayoutKind.Sequential)]
      private struct MSLLHOOKSTRUCT
      {
          public POINT pt;
          public uint mouseData;
          public uint flags;
          public uint time;
          public IntPtr dwExtraInfo;
      }

        #endregion

     

      [DllImport("user32.dll")]
      public static extern int GetAsyncKeyState(Keys vKeys); // USO ESTE PARA LAS TECLAS

    }
}

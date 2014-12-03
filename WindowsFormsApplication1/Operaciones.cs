using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;

namespace Lync
{
    static class Operaciones
    {
       static public bool valuesSET = false;

       #region Dll IMPORT for Mouse Events
       [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
       public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

       private const int MOUSEEVENTF_LEFTDOWN = 0x02;
       private const int MOUSEEVENTF_LEFTUP = 0x04;
       private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
       private const int MOUSEEVENTF_RIGHTUP = 0x10;

        //public const MOUSEEVENTF_LEFTDOWN = &H2;
        //public const MOUSEEVENTF_LEFTUP = &H4;
       #endregion

       static public Config LoadFile(string path)
       {
           Config configNew = new Config();
           string s;
           if (File.Exists(path))
           {
               using (StreamReader sr = new StreamReader(File.OpenRead(path)))
               {
                   int Rows = 0;
                   while ((s = sr.ReadLine()) != null)
                   {
                       if (Rows <3 )
                       {
                           Rows++;
                           continue;
                       }
                       else
                       {
                           configNew = Operaciones.SplitDataFile(s);
                       }
                   }
               }
           }
           return configNew;
       
       }

       static public Config SplitDataFile(string s)
       {
           string[] split = s.Split(new Char[] { ';' });
           Config configNew = new Config();

           configNew.timerInterval = int.Parse(split[0]);
           configNew.extra = (split[1]);
           return configNew;
       }

       static public void Clickear(int x, int y)
       {
           int originalX,originalY;
           originalX = Cursor.Position.X;
           originalY = Cursor.Position.Y;
           Cursor.Position = new Point(x, y);
           MouseEventArgs Click = new MouseEventArgs(MouseButtons.Left,1,x,y,0);
           mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x,(uint) y, 0, 0);
           mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
           Cursor.Position = new Point(originalX, originalY);
       }

       static public void BorrarCartel()
       {
           SendKeys.Send(Convert.ToString(Keys.Enter));
           SendKeys.Send("");
           SendKeys.Send(Convert.ToString(Keys.Enter));       
       }

       static public void AutoRemo()
       {
           //Operaciones.Clickear(960, 325); //Hechizos
           //Operaciones.Clickear(877, 539); //Remo
           //Operaciones.Clickear(871, 563); //Lanzar
           Operaciones.Clickear(718, 125); //Hechizos
           Operaciones.Clickear(636, 163); //Remo
           Operaciones.Clickear(639, 360); //Lanzar
           Thread.Sleep(175);
           Operaciones.Clickear(280, 337); //PJ
           Operaciones.BorrarCartel();
       }


       #region Mouse CLICK VB 6.0
        //Dim XX As Long, YY As Long
        //Call GetMouse(XX, YY)
        //Call SetCursorPos(X, Y)
        //Call mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0)
        //Call mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0)
        //Call SetCursorPos(XX, YY)
        #endregion



       public static Color IfColorBlack(Color colorPotas)
       {
           if (colorPotas.B == Color.Black.B && colorPotas.G == Color.Black.G && colorPotas.R == Color.Black.R && colorPotas.A == Color.Black.A)
           {
               colorPotas = Color.Black;
           }
           return colorPotas;
       }
    }
}

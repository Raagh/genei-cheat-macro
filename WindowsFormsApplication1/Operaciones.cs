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
using MouseKeyboardActivityMonitor.HotKeys;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace Lync
{
    static class Operaciones
    {
       static public bool valuesSET = true;
       static public bool modOfi = false;

       static public void LoadFile(string path)
       {
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
                            Operaciones.SplitDataFile(s);
                       }
                   }
               }
           }
       
       }

       static public void SplitDataFile(string s)
       {
           string[] split = s.Split(new Char[] { ';' });

           Config.timerInterval = int.Parse(split[0]);
           Config.coordRojas.X = int.Parse(split[1]);
           Config.coordRojas.Y = int.Parse(split[2]);
           Config.coordAzules.X = int.Parse(split[3]);
           Config.coordAzules.Y = int.Parse(split[4]);
           Config.coordHechizos.X = int.Parse(split[5]);
           Config.coordHechizos.Y = int.Parse(split[6]);
           Config.coordInventario.X = int.Parse(split[7]);
           Config.coordInventario.Y = int.Parse(split[8]);
           Config.coordLanzar.X = int.Parse(split[9]);
           Config.coordLanzar.Y = int.Parse(split[10]);
           Config.coordRemo.X = int.Parse(split[11]);
           Config.coordRemo.Y = int.Parse(split[12]);
           Config.coordInvi.X = int.Parse(split[13]);
           Config.coordInvi.Y = int.Parse(split[14]);
           Config.coordPJ.X = int.Parse(split[15]);
           Config.coordPJ.Y = int.Parse(split[16]);
           Config.maxLife = int.Parse(split[17]);
           Config.maxMana = int.Parse(split[18]);
           Config.timerInterval2 = int.Parse(split[19]);
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
           SendKeys.Send(" ");
           SendKeys.Send(Convert.ToString(Keys.Enter));       
       }

       static public void AutoRemo()
       {
           if (modOfi == true)
           {
               Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y); //Hechizos
               Operaciones.Clickear(Config.coordRemo.X, Config.coordRemo.Y); //Remo
               Operaciones.Clickear(Config.coordLanzar.X, Config.coordLanzar.Y); //Lanzar
               Thread.Sleep(100);
               Operaciones.Clickear(Config.coordPJ.X, Config.coordPJ.Y); //PJ
               Operaciones.BorrarCartel();
           }
           if (modOfi == false)
           {
               Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y); //Hechizos
               Operaciones.Clickear(Config.coordRemo.X, Config.coordRemo.Y); //Remo
               Operaciones.Clickear(Config.coordLanzar.X, Config.coordLanzar.Y); //Lanzar
               Operaciones.Clickear(Config.coordPJ.X, Config.coordPJ.Y); //PJ
               Operaciones.BorrarCartel();
           }

       }

       static public void AutoInvi()
       {
           if (modOfi == true)
           {
               Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y); //Hechizos
               Operaciones.Clickear(Config.coordInvi.X, Config.coordInvi.Y); //Invi
               Operaciones.Clickear(Config.coordLanzar.X, Config.coordLanzar.Y); //Lanzar
               Thread.Sleep(100);
               Operaciones.Clickear(Config.coordPJ.X, Config.coordPJ.Y); //PJ
               Operaciones.BorrarCartel();
           }
           if (modOfi == false)
           {
               Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y); //Hechizos
               Operaciones.Clickear(Config.coordInvi.X, Config.coordInvi.Y); //Invi
               Operaciones.Clickear(Config.coordLanzar.X, Config.coordLanzar.Y); //Lanzar
               Operaciones.Clickear(Config.coordPJ.X, Config.coordPJ.Y); //PJ
               Operaciones.BorrarCartel();
           }

       }

       public static void AutoLanzar()
       {
           if (modOfi == true)
           {
               Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y); //Hechizos
               Operaciones.Clickear(Config.coordLanzar.X, Config.coordLanzar.Y); //Lanzar
               Thread.Sleep(100);
               Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y); // Inventario
           }
           if (modOfi == false)
           {
               Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y); //Hechizos
               Operaciones.Clickear(Config.coordLanzar.X, Config.coordLanzar.Y); //Lanzar
               Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y); // Inventario
           }
       }


       #region Dll IMPORT for Mouse Events
       [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
       public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

       private const int MOUSEEVENTF_LEFTDOWN = 0x02;
       private const int MOUSEEVENTF_LEFTUP = 0x04;
       private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
       private const int MOUSEEVENTF_RIGHTUP = 0x10;
       #endregion



    }
}

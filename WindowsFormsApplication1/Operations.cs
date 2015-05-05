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
using WindowsInput;

namespace Lync
{
    static class Operations
    {
       static public bool valuesSET = true;
       static public bool modOfi = false;

       #region Dll IMPORT for Mouse Events
       [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
       public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

       private const int MOUSEEVENTF_LEFTDOWN = 0x02;
       private const int MOUSEEVENTF_LEFTUP = 0x04;
       private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
       private const int MOUSEEVENTF_RIGHTUP = 0x10;
       #endregion

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
                            Operations.SplitDataFile(s);
                       }
                   }
               }
           }
       
       }

       static public void SplitDataFile(string s)
       {
           string[] split = s.Split(new Char[] { ';' });

           Configuration.timerInterval = int.Parse(split[0]);
           Configuration.coordRojas.X = int.Parse(split[1]);
           Configuration.coordRojas.Y = int.Parse(split[2]);
           Configuration.coordAzules.X = int.Parse(split[3]);
           Configuration.coordAzules.Y = int.Parse(split[4]);
           Configuration.coordHechizos.X = int.Parse(split[5]);
           Configuration.coordHechizos.Y = int.Parse(split[6]);
           Configuration.coordInventario.X = int.Parse(split[7]);
           Configuration.coordInventario.Y = int.Parse(split[8]);
           Configuration.coordLanzar.X = int.Parse(split[9]);
           Configuration.coordLanzar.Y = int.Parse(split[10]);
           Configuration.coordRemo.X = int.Parse(split[11]);
           Configuration.coordRemo.Y = int.Parse(split[12]);
           Configuration.coordInvi.X = int.Parse(split[13]);
           Configuration.coordInvi.Y = int.Parse(split[14]);
           Configuration.coordPJ.X = int.Parse(split[15]);
           Configuration.coordPJ.Y = int.Parse(split[16]);
           Configuration.maxLife = int.Parse(split[17]);
           Configuration.maxMana = int.Parse(split[18]);
           Configuration.timerInterval2 = int.Parse(split[19]);
           Configuration.remo = (Keys) Enum.Parse(typeof(Keys), split[20]);
           Configuration.invi = (Keys) Enum.Parse(typeof(Keys), split[21]);
       }

       static public void Clickear(int x, int y)
       {
           Cursor.Position = new Point(x, y);
           mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x,(uint) y, 0, 0);
           mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
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
               int originalX, originalY;
               originalX = Cursor.Position.X;
               originalY = Cursor.Position.Y;
               Operations.Clickear(Configuration.coordHechizos.X, Configuration.coordHechizos.Y); //Hechizos
               Operations.Clickear(Configuration.coordRemo.X, Configuration.coordRemo.Y); //Remo
               Operations.Clickear(Configuration.coordLanzar.X, Configuration.coordLanzar.Y); //Lanzar
               Thread.Sleep(70);
               Operations.Clickear(Configuration.coordPJ.X, Configuration.coordPJ.Y); //PJ
               Cursor.Position = new Point(originalX, originalY);
               Operations.BorrarCartel();
               
           }
           if (modOfi == false)
           {
               int originalX, originalY;
               originalX = Cursor.Position.X;
               originalY = Cursor.Position.Y;
               Operations.Clickear(Configuration.coordHechizos.X, Configuration.coordHechizos.Y); //Hechizos
               Operations.Clickear(Configuration.coordRemo.X, Configuration.coordRemo.Y); //Remo
               Operations.Clickear(Configuration.coordLanzar.X, Configuration.coordLanzar.Y); //Lanzar
               Operations.Clickear(Configuration.coordPJ.X, Configuration.coordPJ.Y); //PJ
               Cursor.Position = new Point(originalX, originalY);
               Operations.BorrarCartel();              
           }

       }

       static public void AutoInvi()
       {
           if (modOfi == true)
           {
               int originalX, originalY;
               originalX = Cursor.Position.X;
               originalY = Cursor.Position.Y;
               Operations.Clickear(Configuration.coordHechizos.X, Configuration.coordHechizos.Y); //Hechizos
               Operations.Clickear(Configuration.coordInvi.X, Configuration.coordInvi.Y); //Invi
               Operations.Clickear(Configuration.coordLanzar.X, Configuration.coordLanzar.Y); //Lanzar
               Thread.Sleep(70);
               Operations.Clickear(Configuration.coordPJ.X, Configuration.coordPJ.Y); //PJ
               Operations.BorrarCartel();
               Cursor.Position = new Point(originalX, originalY);
               
           }
           if (modOfi == false)
           {
               int originalX, originalY;
               originalX = Cursor.Position.X;
               originalY = Cursor.Position.Y;
               Operations.Clickear(Configuration.coordHechizos.X, Configuration.coordHechizos.Y); //Hechizos
               Operations.Clickear(Configuration.coordInvi.X, Configuration.coordInvi.Y); //Invi
               Operations.Clickear(Configuration.coordLanzar.X, Configuration.coordLanzar.Y); //Lanzar
               Operations.Clickear(Configuration.coordPJ.X, Configuration.coordPJ.Y); //PJ
               Operations.BorrarCartel();
               Cursor.Position = new Point(originalX, originalY);
           }

       }

       static public void AutoLanzar()
       {
           if (modOfi == true)
           {
               int originalX, originalY;
               originalX = Cursor.Position.X;
               originalY = Cursor.Position.Y;
               Operations.Clickear(Configuration.coordHechizos.X, Configuration.coordHechizos.Y); //Hechizos
               Operations.Clickear(Configuration.coordLanzar.X, Configuration.coordLanzar.Y); //Lanzar           
               Operations.Clickear(Configuration.coordInventario.X, Configuration.coordInventario.Y); // Inventario            
               Operations.Clickear(originalX, originalY);
               Thread.Sleep(70);
               //Cursor.Position = new Point(originalX, originalY);              
           }
           if (modOfi == false)
           {
               int originalX, originalY;
               originalX = Cursor.Position.X;
               originalY = Cursor.Position.Y;
               Operations.Clickear(Configuration.coordHechizos.X, Configuration.coordHechizos.Y); //Hechizos
               Operations.Clickear(Configuration.coordLanzar.X, Configuration.coordLanzar.Y); //Lanzar
               Operations.Clickear(Configuration.coordInventario.X, Configuration.coordInventario.Y); // Inventario
               Operations.Clickear(originalX, originalY);
               //Cursor.Position = new Point(originalX, originalY);
           }
       }






    }
}

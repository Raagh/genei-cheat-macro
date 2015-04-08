using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lync
{
     static class Configuration
    {
        static public int timerInterval;
        static public Point coordRojas;
        static public Point coordAzules;
        static public Point coordHechizos;
        static public Point coordInventario;
        static public Point coordLanzar;                     // Para MULTI AO CONFIG
        static public Point coordPJ;
        static public Point coordRemo;
        static public Point coordInvi;
        static public string TeclaRemo;
        static public string TeclaInvi;
        static public Keys remo;
        static public Keys invi;
        static public bool AutolanzarON = false;
        static public int maxMana = 0;
        static public int maxLife = 0;

        public static int Address { get; set; }

        public static string AOProcessName { get; set; }

        public static int timerInterval2 { get; set; }
    }
}

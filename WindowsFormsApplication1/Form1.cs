using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net;
using Lync;
using WindowsInput;
using System.Runtime.InteropServices;



namespace Lync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly ManualResetEvent mre = new ManualResetEvent(false);

        bool CheatON = false;       
        static public bool faltaVida = false;
        static public bool selectRojas = true;  // Si estan seleccionadas las rojas
        static public bool selectAzules = false;  // Si estan seleccionadas las azules( por defecto Rojas)

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        #region General Events
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void raaghToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMeForm formNew = new AboutMeForm();
            formNew.ShowDialog();
        }

        

        private void EstadoCheats()
        {
            var webRequest = WebRequest.Create(@"http://sophietoso.com.ar/cheat/el_siscador.txt");
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                if (strContent != "liberado")
                {
                    MessageBox.Show("Genei Cheat Bloqueado");
                    Application.Exit();
                }
            }       
        }

        private void cheatAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Genei Cheat 2.0BETA for Argentum Online @CopyLeft 2015");
        }

      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string AutopotInterval = Convert.ToString(listBox1.SelectedItem);
            string AutoLanzarInterval = Convert.ToString(listBox2.SelectedItem);
            if (!string.IsNullOrEmpty(AutopotInterval))
            {
                timer2.Interval = int.Parse(AutopotInterval);
                timer3.Interval = int.Parse(AutoLanzarInterval);
                MessageBox.Show("Se setearon los valores");
                textBox1.Text = Convert.ToString(timer2.Interval);
                textBox2.Text = Convert.ToString(timer3.Interval);
                Operaciones.valuesSET = true;
            }
            else
            {
                Operaciones.valuesSET = true;
                timer2.Interval = int.Parse(textBox1.Text);
                MessageBox.Show("Se usara el valor por defecto a menos que setees uno");
            }
        } //BOTON SET

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text|*.txt";
                saveFileDialog1.Title = "Save Config File";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if(saveFileDialog1.FileName != "")
                     {        
                        using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName)) 
                        {
                            sw.WriteLine("-----------------------------------------------");
                            sw.WriteLine("Configuracion Genei Cheat For Argentum Online");
                            sw.WriteLine("-----------------------------------------------");
                            sw.WriteLine(timer2.Interval + ";" + Config.coordRojas.X + ";" + Config.coordRojas.Y + ";" + Config.coordAzules.X + ";" + Config.coordAzules.Y + ";" + Config.coordBarraVida.X + ";" + Config.coordBarraVida.Y + ";" + Config.coordBarraMana.X + ";" + Config.coordBarraMana.Y + ";" + Config.coordHechizos.X + ";" + Config.coordHechizos.Y + ";" + Config.coordInventario.X + ";" + Config.coordInventario.Y + ";" + Config.coordLanzar.X + ";" + Config.coordLanzar.Y + ";" + Config.coordRemo.X + ";" + Config.coordRemo.Y + ";" + Config.coordInvi.X + ";" + Config.coordInvi.Y + ";" + Config.coordPJ.X + ";" + Config.coordPJ.Y);
                        }                           
                     }
               }
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Text|*.txt";
            OpenFileDialog1.Title = "Load Config File";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog1.FileName != "")
                {
                    Operaciones.LoadFile(OpenFileDialog1.FileName);
                    timer2.Interval = Config.timerInterval;
                    listBox1.SelectedItem = Config.timerInterval;
                    textBox1.Text = Convert.ToString(timer2.Interval);

                }
            }
        }

        private void argentumOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://ComunidadArgentum.com");
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bloqueado hasta el Release, esta en internet, si lo encontas es tuyo");
            //Process.Start("http://github.com/Raagh");
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.button1_Click(sender, e);
            }
        }  

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Win32.UnHook();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConfigForm ConfigNew = new ConfigForm();
            ConfigNew.ShowDialog();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Operaciones.modOfi == false)
            {
                Operaciones.modOfi = true;
            }
            else if (Operaciones.modOfi == true)
            {
                Operaciones.modOfi = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
    

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
          

        }

        #endregion


        #region MasterEvents

        private void Form1_Load(object sender, EventArgs e)
        {
            EstadoCheats();
            textBox1.Text = Convert.ToString(timer2.Interval);
            textBox2.Text = Convert.ToString(timer3.Interval);
            comboBox1.SelectedItem = "Sin Autopot";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem != "Sin Autopot")
            {
                if (Operaciones.valuesSET == true)
                {
                    if (timer3.Enabled == false)
                    {
                        timer3.Enabled = true;
                    }
                    else if (timer3.Enabled == true)
                    {
                        timer3.Enabled = false;
                    }
                    if (timer2.Enabled == false)
                    {
                        timer2.Enabled = true;
                        this.WindowState = FormWindowState.Minimized;
                        Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
                        Operaciones.Clickear(Config.coordRojas.X, Config.coordRojas.Y);  //Rojas
                        Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y);  //Hechizos           
                    }
                    else if (timer2.Enabled == true)
                    {
                        timer2.Enabled = false;
                        this.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    MessageBox.Show("Setea el intervalo");
                }     
            }
            else if (comboBox1.SelectedItem == null || comboBox1.SelectedItem == "Sin Autopot" && CheatON == false)
            {
                MessageBox.Show("Solo se activara el Remo/Invi + AutoLanzar");
            
            }      
            Win32._hookID = Win32.SetHook(Win32._proc2);
            Config.AutolanzarON = true;
            if (CheatON)
            {
                CheatON = false;
                button1.Text = "Activar Cheat";
            }
            else
            {
                CheatON = true;
                button1.Text = "Desactivar";
            }



        } //BOTON ACTIVAR

        private void timer2_Tick(object sender, EventArgs e)     // TIMER AUTOPOTAS
        {
            #region Autopot PIXEL VIEJO
            //InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);   // PARA TESTEAR AMIGO  
            //if (Config.Pixel)
            //{
            //    #region autopotas Pixel             
            //    Color colorRojas = new Color();
            //    Color colorAzules = new Color();
            //    colorRojas = Win32.GetPixelColor(Config.coordBarraVida.X, Config.coordBarraVida.Y); //Tomamos como esta la barra de vida(rojas)
            //    colorAzules = Win32.GetPixelColor(Config.coordBarraMana.X, Config.coordBarraMana.Y); //Tomamos como esta la barra de mana(azules)
            //    if (colorRojas != Config.ColorBarraVida && selectAzules == true) // si falta vida y estan seleccionadas las azules, cambiamos a las rojas y tomamos)
            //    {
            //        Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
            //        Operaciones.Clickear(Config.coordRojas.X, Config.coordRojas.Y);  //Rojas
            //        InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
            //        faltaVida = true;
            //        selectAzules = false;
            //        selectRojas = true;
            //    }
            //    else if (colorRojas != Config.ColorBarraVida && selectRojas == true) // si falta vida y estan seleccionadas las rojas,tomamos)
            //    {
            //        InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
            //        faltaVida = true;
            //        selectAzules = false;
            //    }
            //    else if (colorRojas == Config.ColorBarraVida)
            //    {
            //        faltaVida = false;
            //    }
            //    if (faltaVida == false) // Siempre se prioriza la toma de rojas antes que las de azules, si te moris no hay mana que te sirva :)
            //    {
            //        if (colorAzules != Config.ColorBarraMana && selectAzules == true) // si falta mana y estan seleccionadas las azules, tomamos)
            //        {
            //            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
            //            selectRojas = false;
            //        }
            //        else if (colorAzules != Config.ColorBarraMana && selectAzules == false) // si falta mana y estan seleccionadas las rojas, cambiamos a las azules y tomamos)
            //        {
            //            Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
            //            Operaciones.Clickear(Config.coordAzules.X, Config.coordAzules.Y);  //Azules
            //            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
            //            selectRojas = false;
            //            selectAzules = true;
            //        }
            //    }
            //    
            //}
            #endregion

            #region autopotas Mem

            Process process = Process.GetProcessesByName(Config.AOProcessName)[0]; // Cambia hackme por el proceso del ao, aca voy a hacer un ComboBox con varios aos
            IntPtr processHandle = OpenProcess(0x001F0FFF, false, process.Id);

            int structAddress = Config.Address; //  Pointer to the struct that holds all values.
            int lifeAddress = MemoryManagment.Read(processHandle, structAddress);
            int manaAddress = MemoryManagment.Read(processHandle, structAddress + 4);
            int life = lifeAddress / 65537;
            int mana = manaAddress / 65537;
            if ((life * 100 / Config.maxLife < 90) && selectAzules == true) // si falta vida y estan seleccionadas las azules, cambiamos a las rojas y tomamos)
            {
                Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
                Operaciones.Clickear(Config.coordRojas.X, Config.coordRojas.Y);  //Rojas
                InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                faltaVida = true;
                selectAzules = false;
                selectRojas = true;
            }
            else if ((life * 100 / Config.maxLife < 90) && selectRojas == true) // si falta vida y estan seleccionadas las rojas,tomamos)
            {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                faltaVida = true;
                selectAzules = false;
            }
            else if (Config.maxLife == life)
            {
                faltaVida = false;
            }
            if (faltaVida == false) // Siempre se prioriza la toma de rojas antes que las de azules, si te moris no hay mana que te sirva :)
            {
                if ((mana * 100 / Config.maxMana < 90) && selectAzules == true) // si falta mana y estan seleccionadas las azules, tomamos)
                {
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                    selectRojas = false;
                }
                else if ((mana * 100 / Config.maxMana < 90) && selectAzules == false) // si falta mana y estan seleccionadas las rojas, cambiamos a las azules y tomamos)
                {
                    Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
                    Operaciones.Clickear(Config.coordAzules.X, Config.coordAzules.Y);  //Azules
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                    selectRojas = false;
                    selectAzules = true;
                }
            }

            #endregion

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Win32.GetAsyncKeyState(Config.remo)))
            {
                Operaciones.AutoRemo();
            }

            if (Convert.ToBoolean(Win32.GetAsyncKeyState(Config.invi)))
            {
                Operaciones.AutoInvi();
            }
        }    // TIMER AUTOREMO/INVI

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tierras del Norte")
            {
                if (Config.TDN == false)
                {
                    Config.TDN = true;
                    Config.Address = 0x0050E248;
                    Config.AOProcessName = "Tierras del Norte";
                }
                else if (Config.TDN == true)
                {
                    Config.TDN = false;
                }
                     
            }
            if (comboBox1.Text == "Tierras de Lobos")
            {
                if (Config.TDLobos == false)
                {
                    Config.TDLobos = true;
                    Config.Address = 0x005241F8;
                    Config.AOProcessName = "Tierras de Lobos";
                }
                else if (Config.TDLobos == true)
                {
                    Config.TDLobos = false;
                }
            }
        }   //Combobox With AO Servers


        #endregion

  

    
   
    }
}

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
    public partial class BasicForm : Form
    {
        public BasicForm()
        {
            InitializeComponent();
        }

        private readonly ManualResetEvent mre = new ManualResetEvent(false);

        public bool CheatON = false;       
        static public bool faltaVida = false;
        static public bool selectRojas = true;  // Si estan seleccionadas las rojas
        static public bool selectAzules = false;  // Si estan seleccionadas las azules( por defecto Rojas)

      

        #region General Events
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void raaghToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMeForm formNew = new AboutMeForm();
            formNew.ShowDialog();
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
            if (!string.IsNullOrEmpty(AutopotInterval) && !string.IsNullOrEmpty(AutoLanzarInterval))
            {
                timer2.Interval = int.Parse(AutopotInterval);
                timer3.Interval = int.Parse(AutoLanzarInterval);
                MessageBox.Show("Se setearon los valores");
                textBox1.Text = Convert.ToString(timer2.Interval);
                textBox2.Text = Convert.ToString(timer3.Interval);
                Operations.valuesSET = true;
            }
            else if (string.IsNullOrEmpty(AutopotInterval) && string.IsNullOrEmpty(AutoLanzarInterval))
            {
                Operations.valuesSET = true;
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
                saveFileDialog1.Title = "Save Configuration";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if(saveFileDialog1.FileName != "")
                     {        
                        using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName)) 
                        {
                            sw.WriteLine("-----------------------------------------------");
                            sw.WriteLine("Configuracion Genei Cheat For Argentum Online");
                            sw.WriteLine("-----------------------------------------------");
                            sw.WriteLine(timer2.Interval + ";" + Configuration.coordRojas.X + ";" + Configuration.coordRojas.Y + ";" + Configuration.coordAzules.X + ";" + Configuration.coordAzules.Y + ";" + Configuration.coordHechizos.X + ";" + Configuration.coordHechizos.Y + ";" + Configuration.coordInventario.X + ";" + Configuration.coordInventario.Y + ";" + Configuration.coordLanzar.X + ";" + Configuration.coordLanzar.Y + ";" + Configuration.coordRemo.X + ";" + Configuration.coordRemo.Y + ";" + Configuration.coordInvi.X + ";" + Configuration.coordInvi.Y + ";" + Configuration.coordPJ.X + ";" + Configuration.coordPJ.Y + ";" + Configuration.maxLife + ";" + Configuration.maxMana + ";" + timer3.Interval + ";" + Configuration.remo.ToString() + ";" + Configuration.invi.ToString() );
                        }                           
                     }
               }
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Text|*.txt";
            OpenFileDialog1.Title = "Load Configuration";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog1.FileName != "")
                {
                    Operations.LoadFile(OpenFileDialog1.FileName);
                    timer2.Interval = Configuration.timerInterval;
                    listBox1.SelectedItem = Configuration.timerInterval;
                    textBox1.Text = Convert.ToString(timer2.Interval);
                    listBox2.SelectedItem = Configuration.timerInterval2;
                    textBox2.Text = Convert.ToString(timer3.Interval);
                }
            }
        }

        private void argentumOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://ComunidadArgentum.com");
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No lo voy a compartir hasta que este terminado.");
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
            Win32Libraries.UnHook();
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
            if (Operations.modOfi == false)
            {
                Operations.modOfi = true;
            }
            else if (Operations.modOfi == true)
            {
                Operations.modOfi = false;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=MkASgMdSfmk");
        }        


        #endregion


        #region MasterEvents

        private void EstadoCheats()
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show("Cheat Bloqueado");
                Application.Exit();
            }
        }

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
                if (Operations.valuesSET == true)
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
                        int originalX, originalY;
                        originalX = Cursor.Position.X;
                        originalY = Cursor.Position.Y;
                        Operations.Clickear(Configuration.coordInventario.X, Configuration.coordInventario.Y);  //Inventario
                        Operations.Clickear(Configuration.coordRojas.X, Configuration.coordRojas.Y);  //Rojas
                        Operations.Clickear(Configuration.coordHechizos.X, Configuration.coordHechizos.Y);  //Hechizos 
                        Cursor.Position = new Point(originalX, originalY);
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
            Win32Libraries._hookID = Win32Libraries.SetHook(Win32Libraries._proc2);
            Configuration.AutolanzarON = true;
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
            #region Autopotas Pixel -- VIEJO --
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

            #region Autopotas Memoria

            int originalX, originalY;

            Process process = Process.GetProcessesByName(Configuration.AOProcessName)[0];
            IntPtr processHandle = MemoryManagement.OpenProcess(0x001F0FFF, false, process.Id); // Abre el proceso del AO seleccionado en el combo box

            int structAddress = Configuration.Address; //  Puntero a la struct donde se guardan todas las variables
            
            int life = 0; 
            int mana = 0;
            if (Configuration.AOProcessName == "FuriusAO")
            {
                int lifeAddress = MemoryManagement.Read(processHandle, structAddress);
                int manaAddress = MemoryManagement.Read(processHandle, structAddress + 8);
                life = lifeAddress ;
                mana = manaAddress ;
            }
            else
            {
                int lifeAddress = MemoryManagement.Read(processHandle, structAddress);
                int manaAddress = MemoryManagement.Read(processHandle, structAddress + 4);
                life = lifeAddress / 65537;
                mana = manaAddress / 65537;
            }
            if ((life * 100 / Configuration.maxLife < 95) && selectAzules == true) // si falta vida y estan seleccionadas las azules, cambiamos a las rojas y tomamos)
            {
                originalX = Cursor.Position.X;
                originalY = Cursor.Position.Y;
                Operations.Clickear(Configuration.coordInventario.X, Configuration.coordInventario.Y);  //Inventario
                Operations.Clickear(Configuration.coordRojas.X, Configuration.coordRojas.Y);  //Rojas               
                InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                Operations.Clickear(Configuration.coordRojas.X, Configuration.coordRojas.Y);
                Operations.Clickear(Configuration.coordRojas.X, Configuration.coordRojas.Y);
                Cursor.Position = new Point(originalX, originalY);
                faltaVida = true;
                selectAzules = false;
                selectRojas = true;
            }
            else if ((life * 100 / Configuration.maxLife < 95) && selectRojas == true) // si falta vida y estan seleccionadas las rojas,tomamos)
            {
                originalX = Cursor.Position.X;
                originalY = Cursor.Position.Y;
                InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                Operations.Clickear(Configuration.coordRojas.X, Configuration.coordRojas.Y);
                Operations.Clickear(Configuration.coordRojas.X, Configuration.coordRojas.Y);
                Cursor.Position = new Point(originalX, originalY);
                faltaVida = true;
                selectAzules = false;
            }
            else if (Configuration.maxLife == life)
            {
                faltaVida = false;
            }
            if (faltaVida == false) // Siempre se prioriza la toma de rojas antes que las de azules, si te moris no hay mana que te sirva :)
            {
                if ((mana * 100 / Configuration.maxMana < 95) && selectAzules == true) // si falta mana y estan seleccionadas las azules, tomamos)
                {
                    originalX = Cursor.Position.X;
                    originalY = Cursor.Position.Y;
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                    Operations.Clickear(Configuration.coordAzules.X, Configuration.coordAzules.Y);
                    Operations.Clickear(Configuration.coordAzules.X, Configuration.coordAzules.Y);
                    Cursor.Position = new Point(originalX, originalY);
                    selectRojas = false;
                }
                else if ((mana * 100 / Configuration.maxMana < 95) && selectAzules == false) // si falta mana y estan seleccionadas las rojas, cambiamos a las azules y tomamos)
                {
                    originalX = Cursor.Position.X;
                    originalY = Cursor.Position.Y;
                    Operations.Clickear(Configuration.coordInventario.X, Configuration.coordInventario.Y);  //Inventario
                    Operations.Clickear(Configuration.coordAzules.X, Configuration.coordAzules.Y);  //Azules                  
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                    Operations.Clickear(Configuration.coordAzules.X, Configuration.coordAzules.Y);
                    Operations.Clickear(Configuration.coordAzules.X, Configuration.coordAzules.Y);
                    Cursor.Position = new Point(originalX, originalY);
                    selectRojas = false;
                    selectAzules = true;
                }
            }

            #endregion

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Win32Libraries.GetAsyncKeyState(Configuration.remo)))
            {
                Operations.AutoRemo();
            }

            if (Convert.ToBoolean(Win32Libraries.GetAsyncKeyState(Configuration.invi)))
            {
                Operations.AutoInvi();
            }
            Thread.Sleep(100);
        }    // TIMER AUTOREMO/INVI

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tierras del Norte")
            {
                Configuration.Address = 0x0050E248;              
            }
            if (comboBox1.Text == "Tierras de Lobos")
            {
                Configuration.Address = 0x005241F8;
            }
            if (comboBox1.Text == "FuriusAO")
            {
                Configuration.Address = 0x0079D4BC;             
            }
            Configuration.AOProcessName = comboBox1.Text;
        }    //Combobox With AO Servers

        #endregion

  
    }
}

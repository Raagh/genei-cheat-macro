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


namespace Lync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private readonly ManualResetEvent mre = new ManualResetEvent(false);

        #region Events
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void raaghToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMeForm formNew = new AboutMeForm();
            formNew.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(timer2.Interval);
            MessageBox.Show("Recorda SIEMPRE configurar la barra de vida/mana estando full vida/mana." +Environment.NewLine+ "(la configuracion de las barras no se guardan en el SaveConfig)");
            //Win32.SetHook();
        }

        private void cheatAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Genei Cheat 1.0 for Argentum Online @CopyLeft 2014");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Operaciones.valuesSET == true)
            {
                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    if (itemChecked.ToString() == "AutoPotas")
                    {
                        if (timer2.Enabled == false)
                        {
                            timer2.Enabled = true;
                            this.WindowState = FormWindowState.Minimized;
                            button1.Text = "Desactivar";
                            Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
                            Operaciones.Clickear(Config.coordRojas.X, Config.coordRojas.Y);  //Rojas
                            Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y);  //Hechizos              
                        }
                        else
                        {
                            timer2.Enabled = false;
                            this.WindowState = FormWindowState.Normal;
                            button1.Text = "Activar";
                        }
                    }
                    if (itemChecked.ToString() == "Remover Paralisis" || itemChecked.ToString() == "Invisibilidad" )
                    {
                        Win32.SetHook();
                    }
                    else
                    {
                        Win32.UnHook();
                    }
                }                 
            }
            else
            {
                MessageBox.Show("Seleccionaste los Valores pero no le diste SET");
            }
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string elString = Convert.ToString(listBox1.SelectedItem);
            if (!string.IsNullOrEmpty(elString))
            {
                timer2.Interval = int.Parse(elString);
                MessageBox.Show("Se setearon los valores");
                textBox1.Text = Convert.ToString(timer2.Interval);
                Operaciones.valuesSET = true;
            }
            else
            {
                MessageBox.Show("No seteaste ningun valor");
            }
        }

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
                            sw.WriteLine(timer2.Interval + ";" + Config.coordRojas.X + ";" + Config.coordRojas.Y + ";" + Config.coordAzules.X + ";" + Config.coordAzules.Y + ";" + Config.coordBarraVida.X + ";" + Config.coordBarraVida.Y + ";" + Config.coordBarraMana.X + ";" + Config.coordBarraMana.Y + ";" + Config.coordHechizos.X + ";" + Config.coordHechizos.Y + ";" + Config.coordInventario.X + ";" + Config.coordInventario.Y + ";" + Config.coordLanzar.X + ";" + Config.coordLanzar.Y + ";" + Config.coordRemo.X + ";" + Config.coordRemo.Y + ";" + Config.coordPJ.X + ";" + Config.coordPJ.Y);
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

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todavia Nada");

        }  //BOTON TEST

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Operaciones.AutoRemo();
        }   // TIMER AUTOREMO

        private void timer2_Tick(object sender, EventArgs e)
        {
            //SendKeys.Send(Convert.ToString(Keys.U)); // PARA TESTEAR AMIGO
            bool faltaVida = false;
            bool selectRojas = false;  // Si estan seleccionadas las rojas
            bool selectAzules = true;  // Si estan seleccionadas las azules( por defecto azules)
            Color colorRojas = new Color();
            Color colorAzules = new Color();
            colorRojas = Win32.GetPixelColor(Config.coordBarraVida.X, Config.coordBarraVida.Y); //Tomamos como esta la barra de vida(rojas)
            colorAzules = Win32.GetPixelColor(Config.coordBarraMana.X, Config.coordBarraMana.Y); //Tomamos como esta la barra de mana(azules)
            //colorAzules = Operaciones.IfColorBlack(colorAzules);
            //colorRojas = Operaciones.IfColorBlack(colorRojas);
            if (colorRojas != Config.ColorBarraVida && selectAzules == true) // si falta vida y estan seleccionadas las azules, cambiamos a las rojas y tomamos)
            {
                Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
                Operaciones.Clickear(Config.coordRojas.X, Config.coordRojas.Y);  //Rojas
                Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y);  //Hechizos
                SendKeys.Send("u");
                faltaVida = true;
                selectAzules = false;
                selectRojas = true;
            }
            else if (colorRojas != Config.ColorBarraVida && selectRojas == true) // si falta vida y estan seleccionadas las rojas,tomamos)
            {
                SendKeys.Send("u");
                faltaVida = true;
                selectAzules = false;
            }
            else if (colorRojas == Config.ColorBarraVida)
            {
                faltaVida = false;
            }
            if (faltaVida == false) // Siempre se prioriza la toma de rojas antes que las de azules, si te moris no hay mana que te sirva :)
            {
                if (colorAzules != Config.ColorBarraMana && selectAzules == true) // si falta mana y estan seleccionadas las azules, tomamos)
                {

                    SendKeys.Send("u");
                    //colorAzules = Operaciones.IfColorBlack(colorAzules);
                    selectRojas = false;
                }
                else if (colorAzules != Config.ColorBarraMana && selectAzules == false) // si falta mana y estan seleccionadas las rojas, cambiamos a las azules y tomamos)
                {
                    Operaciones.Clickear(Config.coordInventario.X, Config.coordInventario.Y);  //Inventario
                    Operaciones.Clickear(Config.coordRojas.X, Config.coordRojas.Y);  //Rojas
                    Operaciones.Clickear(Config.coordHechizos.X, Config.coordHechizos.Y);  //Hechizos
                    SendKeys.Send("u");               
                    //colorAzules = Operaciones.IfColorBlack(colorAzules);
                    selectRojas = false;
                    selectAzules = true;
                }
            }
        }   // TIMER AUTOPOTAS

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.button1_Click(sender, e);
                //this.button3_Click(sender, e);
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

        #endregion


        //private void RemoHandler(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Return)
        //    {
        //        Operaciones.AutoRemo();
        //    }
        //} 

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if (Config.tomoCoord == false)
        //    {
        //        Point pointNew = new Point();
        //        pointNew.X = Cursor.Position.X;
        //        pointNew.Y = Cursor.Position.Y;
        //        Config.coordHechizos = pointNew;
        //    }
            
        //}
   
    }
}

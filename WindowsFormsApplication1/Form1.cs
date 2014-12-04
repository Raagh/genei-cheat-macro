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


namespace Lync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
            textBox1.Text = Convert.ToString(timer1.Interval);
            //Win32.SetHook();
        }

        private void cheatAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Raagh's AO Cheat 1.0 @CopyLeft 2014");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Operaciones.valuesSET == true)
            {
                if (timer1.Enabled == false)
                {
                    timer2.Enabled = true;
                    //timer1.Enabled = true;  // REMO POR AHORA NO
                    button1.Text = "Desactivar";
                    Operaciones.Clickear(608, 120);  //Inventario                                                                                                                       
                    Operaciones.Clickear(641, 176);  // Azules 
                    Operaciones.Clickear(718, 125);  //Hechizos                    
                }
                else
                {
                    timer2.Enabled = false;
                    //timer1.Enabled = false;       // REMO POR AHORA NO
                    button1.Text = "Activar";
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
                timer1.Interval = int.Parse(elString);
                MessageBox.Show("Se Setearon Los Valores");
                textBox1.Text = Convert.ToString(timer1.Interval);
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
                            sw.WriteLine("------------------------------------------");
                            sw.WriteLine("Configuracion Raagh's Cheat Argentum Online");
                            sw.WriteLine("------------------------------------------"); 
                            sw.WriteLine(timer1.Interval + ";" + "Tu Vieja");
                        }                           
                     }
               }
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Text|*.txt";
            OpenFileDialog1.Title = "Load Config File";
            Config configNew = new Config();

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog1.FileName != "")
                {
                    configNew = Operaciones.LoadFile(OpenFileDialog1.FileName);
                    timer1.Interval = configNew.timerInterval;
                    listBox1.SelectedItem = configNew.timerInterval;
                    textBox1.Text = Convert.ToString(timer1.Interval);
                }
            }
        }

        private void argentumOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://ComunidadArgentum.com");
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Blocked Till RELEASE,its on the internet (only for Devs) if you find it, its yours.");
            //Process.Start("http://github.com/Raagh");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color color1 = new Color();
            color1 = Win32.GetPixelColor(Cursor.Position.X, Cursor.Position.Y);
            textBox3.Text = "R:" + color1.R + " G:" + color1.G + " B:" + color1.B;
            int x = 0;
            int y = 0;
            x = Cursor.Position.X;
            y = Cursor.Position.Y;
            textBox2.Text = "x:" + x + ",  y:" + y;
        }  //BOTON TEST


        private void timer1_Tick(object sender, EventArgs e)
        {
            Operaciones.AutoRemo();
        }   // TIMER AUTOREMO

        private void timer2_Tick(object sender, EventArgs e)
        {
            //SendKeys.Send(Convert.ToString(Keys.U)); // PARA TESTEAR AMIGO
            //Operaciones.Clickear(858, 321);  //Inventario                                                                                                                       
            //Operaciones.Clickear(880, 380);  // Azules        // COORDENADAS DE PRUEBA
            //Operaciones.Clickear(960, 325);  //Hechizos
            bool faltaVida = false;
 
            bool selectRojas = false;  // Si estan seleccionadas las rojas
            bool selectAzules = true;  // Si estan seleccionadas las azules( por defecto azules)
            Color colorRojas = new Color();
            Color colorAzules = new Color();
            //colorRojas = Win32.GetPixelColor(912, 695); //Tomamos como esta la barra de vida(rojas)       // COORDENADAS DE PRUEBA
            //colorAzules = Win32.GetPixelColor(912, 670); //Tomamos como esta la barra de mana(azules)
            colorRojas = Win32.GetPixelColor(667, 496); //Tomamos como esta la barra de vida(rojas)
            colorAzules = Win32.GetPixelColor(667, 469); //Tomamos como esta la barra de mana(azules)
            colorAzules = Operaciones.IfColorBlack(colorAzules);
            colorRojas = Operaciones.IfColorBlack(colorRojas);
            if (colorRojas == Color.Black && selectAzules == true) // si falta vida y estan seleccionadas las azules, cambiamos a las rojas y tomamos)
            {
                //Operaciones.Clickear(858, 321);  //Inventario
                //Operaciones.Clickear(847, 380);  //Rojas              // COORDENADAS DE PRUEBA
                //Operaciones.Clickear(960, 325);  //Hechizos
                Operaciones.Clickear(608, 120);  //Inventario
                Operaciones.Clickear(603, 183);  //Rojas
                Operaciones.Clickear(718, 125);  //Hechizos
                while (colorRojas == Color.Black)
                {
                    SendKeys.Send("u");
                    colorRojas = Win32.GetPixelColor(667, 496);
                    colorRojas = Operaciones.IfColorBlack(colorRojas);
                }
                faltaVida = false;
                selectAzules = false;
                selectRojas = true;
            }
            else if (colorRojas == Color.Black && selectRojas == true) // si falta vida y estan seleccionadas las rojas,tomamos)
            {
                while (colorRojas == Color.Black)
                {
                    SendKeys.Send("u");
                    colorRojas = Win32.GetPixelColor(667, 496);
                    colorRojas = Operaciones.IfColorBlack(colorRojas);
                }
                faltaVida = false;
                selectAzules = false;
            }
            if (faltaVida == false) // Siempre se prioriza la toma de rojas antes que las de azules, si te moris no hay mana que te sirva :)
            {
                if (colorAzules == Color.Black && selectAzules == true) // si falta mana y estan seleccionadas las azules, tomamos)
                {
                    while (colorAzules == Color.Black)
                    {
                        SendKeys.Send("u");
                        colorAzules = Win32.GetPixelColor(667, 469);
                        colorAzules = Operaciones.IfColorBlack(colorAzules);
                    }
                    selectRojas = false;
                }
                else if (colorAzules == Color.Black && selectAzules == false) // si falta mana y estan seleccionadas las rojas, cambiamos a las azules y tomamos)
                {
                    //Operaciones.Clickear(858, 321);  //Inventario                                                                                                                       
                    //Operaciones.Clickear(880, 380);  // Azules         // COORDENADAS DE PRUEBA
                    //Operaciones.Clickear(960, 325);  //Hechizos
                    Operaciones.Clickear(608, 120);  //Inventario                                                                                                                       
                    Operaciones.Clickear(641, 176);  // Azules 
                    Operaciones.Clickear(718, 125);  //Hechizos
                    while (colorAzules == Color.Black)
                    {
                        SendKeys.Send("u");
                        colorAzules = Win32.GetPixelColor(667, 469);
                        colorAzules = Operaciones.IfColorBlack(colorAzules);
                    }
                    selectRojas = false;
                    selectAzules = true;
                }
            }
        }   // TIMER AUTOPOTAS

        private void RemoHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Operaciones.AutoRemo();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.button1_Click(sender, e);
                //this.button3_Click(sender, e);
            }
        }

        #endregion

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // убираем хук
            //Win32.UnHook();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hace click en Hechisos");
            this.Cursor = Cursors.Cross;
            Point pointNew = new Point (Cursor.Position.X,Cursor.Position.Y);
            Config.coordHechizos = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Hace click en Inventario");
            this.Cursor = Cursors.Cross;       
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordInventario = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Hace click en las pociones Rojas");
            this.Cursor = Cursors.Cross;
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordRojas = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Hace click en las pociones Azules");
            this.Cursor = Cursors.Cross;
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordAzules = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Hace click en la barra de Vida");
            this.Cursor = Cursors.Cross;
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordBarraVida = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Hace click en la barra de Mana");
            this.Cursor = Cursors.Cross;
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordBarraMana = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Hace click en el boton Lanzar");
            this.Cursor = Cursors.Cross;
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordLanzar = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Hace click en tu PJ");
            this.Cursor = Cursors.Cross;
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordPJ = pointNew;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Terminaste de Configurar las Coordenadas");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }
   
    }
}

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

namespace WindowsFormsApplication1
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
        }

        private void cheatAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Raagh's AO Cheat 1.0 @CopyLeft 2014");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Data.valuesSET == true)
            {
                if (timer1.Enabled == false)
                {
                    timer1.Enabled = true;
                    button1.Text = "Desactivar";
                }
                else
                {
                    timer1.Enabled = false;
                    button1.Text = "Activar";
                }
            }
            else
            {
                MessageBox.Show("Seleccionaste los Valores pero no le diste SET");
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("U");
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
                Data.valuesSET = true;
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
                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text|*.txt";
                saveFileDialog1.Title = "Save Config File";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // If the file name is not an empty string open it for saving.
                    if(saveFileDialog1.FileName != "")
                     {
                        // Saves the Image in the appropriate ImageFormat based upon the
                        // File type selected in the dialog box.
                        // NOTE that the FilterIndex property is one-based.                
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
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Text|*.txt";
            OpenFileDialog1.Title = "Load Config File";
            Config configNew = new Config();

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // If the file name is not an empty string open it for saving.
                if (OpenFileDialog1.FileName != "")
                {
                    configNew = Data.LoadFile(OpenFileDialog1.FileName);
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

        #endregion


    }
}

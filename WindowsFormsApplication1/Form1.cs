using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void raaghToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Raagh is an OldSchool Argentum Online player. He started developing C/C++ on android just a year ago. Now its Working as C# dev, and this is his first WinAPP.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cheatAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Raagh's AO Cheat 1.0 @CopyLeft 2014");
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("U");
        }
    }
}

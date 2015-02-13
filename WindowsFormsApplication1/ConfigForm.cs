using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lync
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordRojas = pointNew;
            MessageBox.Show("Rojas Configuradas");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordAzules = pointNew;
            MessageBox.Show("Azules Configuradas");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordBarraVida = pointNew;
            Config.ColorBarraVida = Win32.GetPixelColor(Config.coordBarraVida.X, Config.coordBarraVida.Y);
            MessageBox.Show("Barra de vida Configurada");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordBarraMana = pointNew;
            Config.ColorBarraMana = Win32.GetPixelColor(Config.coordBarraMana.X, Config.coordBarraMana.Y);
            MessageBox.Show("Barra de mana Configurada");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordHechizos = pointNew;
            MessageBox.Show("Boton de hechizos configurado");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordInventario = pointNew;
            MessageBox.Show("Boton de inventario configurado");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordLanzar = pointNew;
            MessageBox.Show("Boton de lanzar configurado");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordRemo = pointNew;
            MessageBox.Show("Hechizo remover paralisis configurado");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordInvi = pointNew;
            MessageBox.Show("Hechizo invisibilidad configurado");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordPJ = pointNew;
            MessageBox.Show("PJ configurado");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Config.TeclaRemo = label3.Text;
            Config.TeclaInvi = label4.Text;
            label5.Text = "Teclas seteadas";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = Convert.ToString(e.KeyCode);
            label3.Text = Convert.ToString(e.KeyValue);
            Config.remo = e.KeyCode;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.Text = Convert.ToString(e.KeyCode);
            label4.Text = Convert.ToString(e.KeyValue);
            Config.invi = e.KeyCode;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            label3.Text = string.Empty;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            label4.Text = string.Empty;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Config.TeclaRemo) && !String.IsNullOrEmpty(Config.TeclaInvi)) 
            {
                textBox1.Text = Config.TeclaRemo;
                textBox2.Text = Config.TeclaInvi;         
            }
            textBox3.Text = Convert.ToString(Config.maxLife);
            textBox4.Text = Convert.ToString(Config.maxMana);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Config.maxLife=int.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Config.maxMana = int.Parse(textBox4.Text);
        }
    }
}

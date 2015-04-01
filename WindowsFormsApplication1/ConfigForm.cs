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
            MessageBox.Show("Apoya el mouse sobre las Rojas y apreta Enter");
            Point pointNew = new Point();
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordRojas = pointNew;
            MessageBox.Show("Rojas Configuradas");
            MessageBox.Show("Apoya el mouse sobre las Azules y apreta Enter");
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordAzules = pointNew;
            MessageBox.Show("Azules Configuradas");
            MessageBox.Show("Apoya el mouse sobre el boton de hechizos y apreta Enter");
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordHechizos = pointNew;
            MessageBox.Show("Boton de hechizos configurado");
            MessageBox.Show("Apoya el mouse sobre el boton de inventario y apreta Enter");
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordInventario = pointNew;
            MessageBox.Show("Boton de inventario configurado");
            MessageBox.Show("Apoya el mouse sobre el boton de lanzar y apreta Enter");
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordLanzar = pointNew;
            MessageBox.Show("Boton de lanzar configurado");
            MessageBox.Show("Apoya el mouse sobre el hechizo Remover Paralisis y apreta Enter");
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordRemo = pointNew;
            MessageBox.Show("Hechizo remover paralisis configurado");
            MessageBox.Show("Apoya el mouse sobre el hechizo Invisibilidad y apreta Enter");
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordInvi = pointNew;
            MessageBox.Show("Hechizo invisibilidad configurado");
            MessageBox.Show("Apoya el mouse sobre tu pj y apreta Enter");
            pointNew.X = Cursor.Position.X;
            pointNew.Y = Cursor.Position.Y;
            Config.coordPJ = pointNew;
            MessageBox.Show("PJ configurado");
            MessageBox.Show("Configuracion Completada");
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
            if (Config.remo.ToString() != "None" && Config.invi.ToString() != "None") 
            {
                textBox1.Text = Config.remo.ToString();
                textBox2.Text = Config.invi.ToString();
                label5.Text = "Teclas seteadas";
            }
            textBox3.Text = Convert.ToString(Config.maxLife);
            textBox4.Text = Convert.ToString(Config.maxMana);        
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                Config.maxLife = int.Parse(textBox3.Text); 
            }          
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                Config.maxMana = int.Parse(textBox4.Text);
            }         
        }
    }
}

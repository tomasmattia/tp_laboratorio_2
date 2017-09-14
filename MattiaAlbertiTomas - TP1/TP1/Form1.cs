using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void igual_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(textBox1.Text);
            Numero numero2 = new Numero(textBox2.Text);
            resultado.Text = Calculadora.Operar(numero1, numero2, comboBox1.Text).ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void limpiar()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.resultado.Text = "";
            this.comboBox1.SelectedIndex = 0;
        }
    }
}

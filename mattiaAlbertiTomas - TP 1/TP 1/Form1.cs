using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            Resultado.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(textBox1.Text);
            Numero numero2 = new Numero(textBox2.Text);
            Resultado.Text= Calculadora.Operar(numero1, numero2, comboBox1.Text).ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Resultado_Click(object sender, EventArgs e)
        {

        }
    }
}

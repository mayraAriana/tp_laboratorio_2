using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Limpia valores, label y comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label1.Text = "";
            comboBox1.Text = "";
        }

        /// <summary>
        /// Calcula usando el metodo operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void operar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(textBox1.Text);
            Numero num2 = new Numero(textBox2.Text);
            string operador = comboBox1.Text;
            
           // Calculadora resultado = new Calculadora();

            Numero resul = new Numero(Calculadora.operar(num1, num2, operador));

            label1.Text = Convert.ToString(resul.getNumero());          

        }
        /// <summary>
        /// Cierra programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button3_Click(object sender, EventArgs e)
        {
            long num = Convert.ToInt32(textBox1.Text);
            if (num > 0)
            {
                String binario = "";
                while (num > 0)
                {
                    if (num % 2 == 0)
                        label1.Text = binario = "0" + binario;
                    else
                        label1.Text = binario = "1" + binario;

                    num = (long)(num / 2);
                }
                label1.Text = binario;
            }
            else
                if (num < 0)
                    MessageBox.Show("Ingrese solo numeros positivos");
            
        }
        /// <summary>
        /// Convierte a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            decimal conversor = 0;

            label1.Text = conversor.ToString(textBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}

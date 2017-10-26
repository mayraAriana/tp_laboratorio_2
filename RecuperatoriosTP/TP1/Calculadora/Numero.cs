using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public class Numero
    {

        public double numero;

        /// <summary>
        /// constructor sobrecargado
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// constructor sobrecargado
        /// </summary>
        /// <param name="primernumero"></param>
        public Numero(double primernumero)
        {
            this.numero = primernumero;
        }

        /// <summary>
        /// constructor sobrecargado
        /// </summary>
        /// <param name="primernumero"></param>
        public Numero(string primernumero)
        {
            this.setNumero(primernumero);
        }

        /// <summary>
        /// Validacion del string para saber si es un double
        /// </summary>
        /// <param name="NumeroString"></param>
        /// <returns></returns>
        private double validarNumero(string numeroString)
        {
            double final = 0;
            double.TryParse(numeroString, out final);
            return final;
        }

        /// <summary>
        /// get de numero tipo Numero
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// set string
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            //this.numero = validarNumero(numero);
            
            //else
            //{
            //    MessageBox.Show("Uno de los numeros es erroneo");
            //}
            try
            {
                this.numero = validarNumero(numero);
            }
            catch (Exception e)
            {
                MessageBox.Show("Uno de los numeros es erroneo");
                throw;
            }
        }

      

    }
}
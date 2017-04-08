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
        public Numero(string primernumero)
        {
            setNumero(primernumero);
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
        /// Validacion del string para saber si es un double
        /// </summary>
        /// <param name="NumeroString"></param>
        /// <returns></returns>
        private double validarNumero(string NumeroString)
        {
            double primernumero = 0;
            bool resultado = double.TryParse(NumeroString, out primernumero);
            if (resultado == false)
            {
                primernumero = 0;
            }
            else
            {
                primernumero = 1;
            }
            return primernumero;
        }

        /// <summary>
        /// setter del string parseado a double
        /// </summary>
        /// <param name="primernumero"></param>
        private void setNumero(string primernumero)
        {
            if (validarNumero(primernumero) == 1)
            {
                double.TryParse(primernumero, out numero);
            }
            else
            {
                MessageBox.Show("Uno de los numeros es erroneo");
            }
        }

        /// <summary>
        /// getter de un numero del tipo "Numero"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public double getNumero(Numero numero)
        {
            double retorno;
            retorno = this.numero;

            return retorno;
        }

    }
}
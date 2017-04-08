using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public class Calcular
    {
        /// <summary>
        /// Metodo que realiza las operaciones aritmeticas.
        /// </summary>
        /// <param name="primernumero"></param>
        /// <param name="segundonumero"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public double operar(Numero primernumero, Numero segundonumero, string operador)
        {
            double resultado = 0;

            if(validarOperador(operador) == 1)
            {
                switch (operador)
                {
                    case "+":
                        resultado = primernumero.numero + segundonumero.numero;
                        break;
                    case "-":
                        resultado = primernumero.numero - segundonumero.numero;
                        break;
                    case "*":
                        resultado = primernumero.numero * segundonumero.numero;
                        break;
                    case "/":
                        if (segundonumero.numero != 0)
                        {
                            resultado = primernumero.numero / segundonumero.numero;
                        }
                        else
                        {
                            MessageBox.Show("No es posible dividir por 0");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Coloque un operador previamente.");
            }

                return resultado;
            }

        /// <summary>
        /// metodo de validacion
        /// </summary>
        /// <param name="operando"></param>
        /// <returns></returns>
        public double validarOperador(string operando)
        {
            double primernumero = 0;
            if (operando == "+"|| operando =="*"||operando == "-"|| operando == "/")
            {
                primernumero = 1;
            }
            else
            {
                primernumero = 0;
            }

            return primernumero;
        }

    }
}

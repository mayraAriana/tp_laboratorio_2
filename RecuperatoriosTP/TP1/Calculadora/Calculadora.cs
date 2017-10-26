using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public class Calculadora
    {
        /// <summary>
        /// Operaciones aritmeticas
        /// </summary>
        /// <param name="primernumero"></param>
        /// <param name="segundonumero"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado;

            switch (operador)
            {
                case "+":
                    resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    //Valida division por 0 o letra.
                    if (numero2.getNumero() == 0)
                    {
                        resultado = 0;
                        MessageBox.Show("Error, ingrese un operando valido.");
                    }                  
                    else
                        resultado = numero1.getNumero() / numero2.getNumero();
                    break;
                default:
                    resultado = 0;
                    MessageBox.Show("Error, ingrese un operador válido");
                    break;
            }
            return resultado;

           
        }
        /// <summary>
        /// Validacion de operador
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static string validarOperador(string operador)
        {
            if (operador != "+" || operador != "*" || operador != "-" || operador != "/")
            {
                operador = "+";
            }

            return operador;
        }

    }
}

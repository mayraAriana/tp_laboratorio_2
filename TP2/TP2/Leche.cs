using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace TP2
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        ETipo _tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="codigoDeBarras"></param>
        /// <param name="marca"></param>
        /// <param name="colorPrimarioEmpaque"></param>
        public Leche(string codigoDeBarras, EMarca marca, ConsoleColor colorPrimarioEmpaque)
            : base(codigoDeBarras, marca, colorPrimarioEmpaque)
        {
            _tipo = ETipo.Entera;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Muestra los datos de la leche
        /// </summary>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

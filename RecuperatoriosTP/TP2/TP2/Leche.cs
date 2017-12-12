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
        /// 

        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente,color,marca)
        {
            this._tipo = ETipo.Entera;
        }


        //public Leche(string codigoDeBarras, EMarca marca, ConsoleColor colorPrimarioEmpaque, ETipo _tipo)
        //    : base(codigoDeBarras, marca, colorPrimarioEmpaque)
        //{
        //    _tipo = ETipo.Entera;
        //}

        public Leche(EMarca marca, string patente, ConsoleColor color,ETipo _tipo)
            : this(marca, patente, color)
        {
            this._tipo = _tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Muestra los datos de la leche
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine((string)this);
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("TIPO : " + this._tipo.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

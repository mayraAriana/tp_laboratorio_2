using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    [Serializable]
    public abstract class Universitario: Persona
    {
        public enum EClases { }
        public enum EEstadoCuenta { }  // no menciona Enums.
        
        private int _legajo;

        public Universitario() { }

        public int legajo
        {
            get { return this._legajo; }
            set { this._legajo = value; }
        }

        #region Constructores

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos de Universitario
        /// </summary>
        /// <return name="stringBuilder "></returns>

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this._legajo.ToString());
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// verifica si dos personas son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.GetType() == pg2.GetType() && (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// verifica si dos personas son distintas.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
         
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}

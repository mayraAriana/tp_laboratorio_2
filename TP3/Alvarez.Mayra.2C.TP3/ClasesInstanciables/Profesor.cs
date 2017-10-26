using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
   [Serializable]
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region Propiedades
        public Universidad.EClases[] ClasesDelDia
        {
            get
            {
                Universidad.EClases[] arrayEclases = new Universidad.EClases[2];
                this._clasesDelDia.CopyTo(arrayEclases, 0);
                return arrayEclases;
            }
            set
            { this._clasesDelDia = new Queue<Universidad.EClases>(value); }

        }
        public Profesor() { }

        #endregion

        #region Constructores

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int legajo, string nombre, string apellido,string dni, ENacionalidad nacionalidad):
            base(legajo ,nombre,apellido, dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public void _randomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(3));
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(3));

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns name="stringBuilder"></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Muestras las clases del profesor
        /// </summary>
        /// <returns name="stringBuilder"></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases clase in this._clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();

        }

        /// <summary>
        /// Invoca al metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si un profesor es igual a una clase(la da)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si un profesor es distinto a una clase(no la da)
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}

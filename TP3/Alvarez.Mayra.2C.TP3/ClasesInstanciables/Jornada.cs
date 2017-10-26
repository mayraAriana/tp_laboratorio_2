using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using System.IO;
using Archivos;
using Archivos.cs;

namespace ClasesInstanciables
{
    [Serializable]
    public class Jornada
    {
        public List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _profesor;

        public List<Alumno> LsAlumnos
        {
            get { return this._alumnos; }
            set
            { this._alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get
            { return this._clase; }
            set
            { this._clase = value; }
        }
        public Profesor Profesor
        {
            get
            { return this._profesor; }
            set
            { this._profesor = value; }
        }

        #region Constructores

        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor profesor) :
            this()
        {
            this._clase = clase;
            this._profesor = profesor;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda una jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();
            if (archivoTexto.guardar("Jornada.txt", jornada.ToString()))
                return true;
            return false;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns name="stringBuilder" ></returns>
        /// 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this._clase + " POR \n" + this._profesor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("-------------------------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// Agrega un alumno a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns name="j"></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }
        /// <summary>
        /// Verifica si un alumno forma parte de la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si un alumno no forma parte de la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        #endregion

    }
}

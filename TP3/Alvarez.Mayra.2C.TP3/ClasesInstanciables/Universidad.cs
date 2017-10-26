using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;
using System.Xml;
using System.Xml.Serialization;

namespace ClasesInstanciables
{
     [Serializable]
    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Profesor> _profesores;
        private List<Jornada> _jornada;

        public enum EClases { Programacion = 0, Laboratorio = 1, Legislacion = 2, SPD = 3 };

        #region Propiedades
        public List<Alumno> LsAlumno
        {
            get
            { return this._alumnos; }
            set
            { this._alumnos = value; }
        }

        public List<Profesor> LsProf
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }
        public List<Jornada> LsJorn
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }
        #endregion

        #region Constructores

        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornada = new List<Jornada>();
        }

        #endregion

        #region Propiedades
    
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this._jornada.Count)
                    return this._jornada[i];
                else
                    return null;
            }
        }

        #endregion  

        #region Metodos
        /// <summary>
        /// Guarda los datos de la universidad en un archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns name="aux"></returns>
        public static bool Guardar(Universidad uni)
        {
            bool aux = false;
            try
            {
                Archivos.cs.Xml<Universidad> archivoXml = new Archivos.cs.Xml<Universidad>();
                aux = archivoXml.guardar("Universidad.xml", uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return aux;
        }
        /// <summary>
        /// Lee los datos de la universidad de un archivo xml
        /// </summary>
        /// <param></param>
        /// <returns name=uni ></returns>
        public static Universidad Leer()
        {
            Universidad uni;
            try
            {
                Archivos.cs.Xml<Universidad> auxLeer = new Archivos.cs.Xml<Universidad>();
                auxLeer.leer("Universidad.xml", out uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return uni;
        }
        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <returns name="stringBuilder"></returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in u._jornada)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Invoca al metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Verifica si universidad es igual a un alumno
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno item in u._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si universidad es distinto a un alumno
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }
        /// <summary>
        /// Verifica si universidad es igual a un instructor
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach (Profesor item in u._profesores)
            {
                if (item == p)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si universidad es distinto a un instructor
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }
        /// <summary>
        /// Verifica si universidad es igual a una clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u._profesores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Verifica si universidad es igual distinto a una clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesorAux = null;
            foreach (Profesor item in u._profesores)
            {
                if (item != clase)
                {
                    profesorAux = item;
                    break;
                }
            }
            return profesorAux;            
        }
        /// <summary>
        /// Agrega un alumno a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return u;
        }
        /// <summary>
        /// Agrega un profesor al gimnasio
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
                u._profesores.Add(p);
            return u;
        }
        /// <summary>
        /// Agrega una clase a universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            try
            {
                Jornada jornada = new Jornada(clase, (u == clase));
                u._jornada.Add(jornada);
                foreach (Alumno item in u._alumnos)
                {
                    if (item == clase)
                        jornada._alumnos.Add(item);
                }
                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
            

 }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Extranjero, Argentino }; 
        
        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;

        #region Constructores

        public Persona()
        { }


        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = ValidarDni(nacionalidad, dni);
        }

        #endregion

        #region Propiedades

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }

        public string stringToDNI
        {
            set { this._dni = ValidarDni(this._nacionalidad,value); }
        }
       

        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el dni corresponda a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato < 1 || dato > 89999999)
                    throw new NacionalidadInvalidaException();
                else
                    return dato;
            }
            else
            {
                if (dato > 90000000 && dato < 99999999)
                    return dato;
                else
                    throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Valida que DNI tenga formato válido retornando la validación de caracteres y corresponda con la nacionalidad.
        /// </summary>
        /// <param name = "nacionalidad" ></ param >
        /// < param name="dato"></param>
        /// <returns ValidarDni(nacionalidad,numero)></ returns >

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            int numero = 0;
            for (int i = 0; i < dato.Length; i++)
            {
                if (!int.TryParse(dato, out numero))
                {
                    throw new Exception("Error, DNI inválido, solo numeros");
                }
                else
                    numero = int.Parse(dato);
            }

            return ValidarDni(nacionalidad, numero);

        }


        /// <summary>
        /// Valida que el nombre y apellido sean caracteres permitidos.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns name= "dato"></returns>
        /// 

        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (dato[i] < (char)65 || dato[i] > (char)122)
                {
                    throw new Exception();
                }
            }
            return dato;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Retorna los datos de la persona
        /// </summary>
        /// <returns name="stringBuilder"></returns>
        /// 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad.ToString());
            
            return sb.ToString();
        }

        #endregion







    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.cs
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Escribe los caracteres de la secuencia "datos". Guardando el archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns name= "aux" ></returns>
        
        public bool guardar(string archivo, string datos)
        {
            bool aux = true;
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(datos);
                    //escribe todos los caracteres desde la posicion actual hasta el final de la secuencia.
                }
            }
            catch
            {
                aux = false;
                throw new Exception("No se pudo guardar en el archivo de texto.");
            }
            return aux;
        }

        /// <summary>
        /// Lectura de los caracteres de una secuencia de bytes.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns name= "aux" ></returns>
        public bool leer(string archivo, out string datos)
        {
            StringBuilder sb = new StringBuilder();

            bool aux = true;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                    sb.Append(reader.ReadToEnd());
                //lee todos los caracteres desde la posicion actual hasta el final de la secuencia.
            }
            catch
            {
                aux = false;
                throw new Exception("No se pudo leer del archivo de texto.");

            }
            datos = sb.ToString();
            return aux;
        }
    }
}
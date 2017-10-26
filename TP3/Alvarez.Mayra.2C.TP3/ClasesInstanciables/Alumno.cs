﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    [Serializable]
    public class Alumno: Universitario
    {
        public enum EEstadoCuenta { Deudor, AlDia, Becado };
        
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
        { }

        public Universidad.EClases ClaseQueToma
        {
            get
            { return this._claseQueToma; }
            set
            { this._claseQueToma = value; }

        }
        public EEstadoCuenta EstadoCuenta
        {
            get
            { return this._estadoCuenta; }
            set
            { this._estadoCuenta = value; }
        }

        
        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : this(legajo, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.Becado)
        { 
        
        }

        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :base(legajo,nombre,apellido, dni, nacionalidad)
        {
            this._estadoCuenta = estadoCuenta;
            this._claseQueToma = claseQueToma;
        }

        #region Sobrecargas
        /// <summary>
        /// Retorna las clases que toma el alumno
        /// </summary>
        /// <returns name="stringBuilder"></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TOMA CLASES DE " + this._claseQueToma.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo.ToString());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Invoca al metodo mostrardatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Verifica si un alumno es igual a una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        /// <summary>
        /// Verifica si un alumno es distinto a una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            return false;
        }

        #endregion





    }
}

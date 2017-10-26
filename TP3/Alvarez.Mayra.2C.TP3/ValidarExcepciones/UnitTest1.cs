using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using ClasesAbstractas;
using Excepciones;

namespace Test
{
    [TestClass]
    public class ValidarExcepciones
    {
        /// <summary>
        /// Valida Excepcion.
        /// </summary>
        [TestMethod]
        public void TestDni()
        {
            try
            {
                Profesor prof = new Profesor(155, "Gonzalo", "Rodriguez", "TresCuatro751983", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Valida que no haya valores nulos en algun atributo.
        /// </summary>
        [TestMethod]
        public void TestNulos()
        {
            Profesor profesor = new Profesor(155, "Gonzalo", "Rodriguez", "34751983", Persona.ENacionalidad.Argentino);
            Assert.AreNotEqual(null, profesor.legajo);
            Assert.AreNotEqual(null, profesor.Nombre);
            Assert.AreNotEqual(null, profesor.Apellido);
            Assert.AreNotEqual(null, profesor.DNI);
            Assert.AreNotEqual(null, profesor.Nacionalidad);
        }

        /// <summary>
        /// Valida que no haya valores nulos en algun atributo.
        /// </summary>
        [TestMethod]
        public void TestGimnasioInstancia()
        {
            Universidad universidad = new Universidad();              

            Assert.AreNotEqual(null, universidad.LsAlumno);
            Assert.AreNotEqual(null, universidad.LsProf);
            Assert.AreNotEqual(null, universidad.LsJorn);
        }
    }
}

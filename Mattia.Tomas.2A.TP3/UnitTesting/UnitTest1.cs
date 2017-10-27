using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarExcepciones1()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(3, "José", "Gutierrez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(3, "Juana", "Martinez", "42234458", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            gim += a1;
            try
            {
                gim+=a2;
                Assert.Fail("Debería avisar que el alumno ya esta");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void ValidarExcepciones2()
        {
            Universidad gim = new Universidad();
            try
            {
                Alumno a1 = new Alumno(1, "Jorge", "Rojas", "1", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Debería avisar que la nacionalidad es invalida.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void ValidarNumeros()
        {
            Universidad gim = new Universidad();
            try
            {
                Alumno a1 = new Alumno(1, "Jorge", "Rojas", "estoEsInvalido", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Debería avisar que el DNI es invalido.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void ValidarNulos()
        {
            Alumno a1 = new Alumno();
            try
            {
                a1.ToString();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno() : this(0,"Falta nombre", "Falta apellido", "1",ENacionalidad.Argentino,Universidad.EClases.Programacion)
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Sobreescribe mostrarDatos y le agrega el estado de la cuenta
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            if(this._estadoCuenta== EEstadoCuenta.Becado)
            {
                return base.MostrarDatos() + "ESTADO DE CUENTA: Becado \n\n";
            }
            else
            {
                if(this._estadoCuenta == EEstadoCuenta.Deudor)
                {
                    return base.MostrarDatos() + "ESTADO DE CUENTA: Deudor\n\n";
                }
            }
            return base.MostrarDatos() + "ESTADO DE CUENTA: Al dia\n\n";
        }

        /// <summary>
        /// retorna el string generado en mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>bool</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>bool</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma != clase;
        }
    }


}

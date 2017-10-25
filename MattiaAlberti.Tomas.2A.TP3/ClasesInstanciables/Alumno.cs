using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        public enum EEstadoCuenta { Becado, Deudor, AlDia }
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno() : base()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        public Universidad.EClases ClaseQueToma { get { return _claseQueToma; } }

        public new string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase();
        }

        public override string ParticiparEnClase()
        {
            return "\nTOMA CLASES DE :" + this._claseQueToma;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
    }
}

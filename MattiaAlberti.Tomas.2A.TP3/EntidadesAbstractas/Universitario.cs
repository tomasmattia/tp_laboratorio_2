using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int _legajo;

        protected virtual string MostrarDatos()
        {
            return ((Persona)this).ToString() + "\nLEGAJO: " + this._legajo;
        }

        public Universitario() : base()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        public abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return (obj is Universitario && this == (Universitario)obj);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI); // REVISAR ESTO
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}

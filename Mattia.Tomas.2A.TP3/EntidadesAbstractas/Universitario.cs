using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        public Universitario() : base()
        {
            _legajo = 0;
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            _legajo = legajo;
        }

        public override bool Equals(object obj)
        {
            return obj is Universitario && (Universitario)obj == this;
        }

        /// <summary>
        /// Retornará todos los datos del Universitario.
        /// </summary>
        /// <returns>string</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLEGAJO: " + this._legajo+"\n";
        }

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="pg1">Un universitario</param>
        /// <param name="pg2">Un universitario</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI;
        }

        /// <summary>
        /// Dos Universitario serán distintos si su Legajo o DNI son distintos
        /// </summary>
        /// <param name="pg1">Un universitario</param>
        /// <param name="pg2">Un universitario</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();
    }


}

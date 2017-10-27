using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : base(0,null,null,null,ENacionalidad.Argentino)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Sobreescribe mostrarDatos con datos personales del profesor
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        /// <summary>
        /// retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase()
        {
            string stringRetorno = "CLASES DEL DÍA : ";
            foreach (Universidad.EClases e in _clasesDelDia)
            {
                stringRetorno += e.ToString()+" / ";
            }
            stringRetorno += "\n";
            return stringRetorno;
        }

        /// <summary>
        /// Hará públicos los datos del Profesor
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Se asignarán dos clases al azar al Profesor. Las dos clases pueden o no ser la misma.
        /// </summary>
        private void _randomClases()
        {
            while (this._clasesDelDia.Count < 2)
            {
                int clase = random.Next(0, 3);
                this._clasesDelDia.Enqueue((Universidad.EClases)clase);
            }
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases claseProfe in i._clasesDelDia)
            {
                if (claseProfe == clase)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }

}

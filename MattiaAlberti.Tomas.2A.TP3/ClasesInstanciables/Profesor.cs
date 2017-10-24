using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }

        public new string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        public override string ParticiparEnClase()
        {
            string stringRetorno = "CLASES DEL DÍA :\n";
            foreach (Universidad.EClases e in _clasesDelDia)
            {
                stringRetorno += e.ToString();
            }
            return stringRetorno;
        }

        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase();
        }

        private void _randomClases()
        {
            while (this._clasesDelDia.Count < 2)
            {
                int clase = random.Next(1, 4);
                switch (clase)
                {
                    case 1:
                        _clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        _clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        _clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 4:
                        _clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }

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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}

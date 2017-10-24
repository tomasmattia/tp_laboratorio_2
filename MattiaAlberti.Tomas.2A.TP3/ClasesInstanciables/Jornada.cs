using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._instructor = instructor;
            this._clase = clase;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno aEnJornada in j.Alumnos)
            {
                if (aEnJornada == a)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        public override string ToString()
        {
            string stringRetorno = "PROFESOR: " + this.Instructor.ToString() + "\nALUMNOS:\n";
            foreach (Alumno a in this.Alumnos)
            {
                stringRetorno += a.ToString();
            }
            return stringRetorno;
        }

        //public static string Leer()
        //{
        //    string stringRetorno = ""
        //}
    }
}

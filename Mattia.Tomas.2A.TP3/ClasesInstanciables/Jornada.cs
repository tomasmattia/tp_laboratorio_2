using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;
using System.IO;


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

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j">una jornada</param>
        /// <param name="a">un alumno</param>
        /// <returns>bool</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j._clase;
        }

        /// <summary>
        /// Una Jornada será distinto a un Alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j">una jornada</param>
        /// <param name="a">un alumno</param>
        /// <returns>bool</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;
            foreach (Alumno alumnoJornada in j.Alumnos)
            {
                if (alumnoJornada == a)
                {
                    flag = true;
                }
            }
            if (flag == false)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Mostrará todos los datos de la Jornada
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string stringRetorno = "CLASE: "+this._clase+ " PROFESOR: " + this.Instructor.ToString() + "\nALUMNOS:\n";
            foreach (Alumno a in this.Alumnos)
            {
                stringRetorno += a.ToString();
            }
            stringRetorno += "\n-------------------------------------------------------\n";
            return stringRetorno;
        }

        /// <summary>
        /// Guardará los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>bool</returns>
        static public bool Guardar(Jornada jornada)
        {
            Texto Guardador = new Texto();
            Guardador.Guardar("Jornada.txt", jornada.ToString());
            if(File.Exists("Jornada.txt"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retornará los datos de la Jornada como texto
        /// </summary>
        /// <returns></returns>
        static public string Leer()
        {
            string linea;
            Texto Cargador = new Texto();
            Cargador.Leer("Jornada.txt", out linea);
            return linea;            
        }
    }

}

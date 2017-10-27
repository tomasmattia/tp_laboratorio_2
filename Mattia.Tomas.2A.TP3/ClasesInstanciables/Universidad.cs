using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Archivos;

namespace ClasesInstanciables
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Jornada))]
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }


        /// <summary>
        /// Genera un string con todos los datos de la universidad
        /// </summary>
        /// <param name="gim">una universidad</param>
        /// <returns>string</returns>
        private static string MostrarDatos(Universidad gim)
        {
            string stringRetorno = "JORNADA: \n";
            foreach(Jornada jor in gim.Jornadas)
            {
                stringRetorno += jor.ToString();
            }
            return stringRetorno;
        }

        /// <summary>
        /// Retorna el string generado en mostrarDatos
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en ella.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno aUni in g.alumnos)
            {
                if (aUni == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Un Universidad será distinto a un Alumno si el mismo no está inscripto en ella.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una Universidad será igual a un Profesor si el mismo está dando clases en ella, si no encuentra ninguno arroja el mensaje
        /// </summary>
        /// <param name="g">Una Universidad</param>
        /// <param name="i">un Profesor</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor iUni in g.profesores)
            {
                if (iUni == i)
                {
                    return true;
                }
            }
            Console.WriteLine("NO HAY PROFESOR PARA LA CLASE");
            return false;
        }

        /// <summary>
        /// Una Universidad será distinto a un Profesor si el mismo no está dando clases en ella
        /// </summary>
        /// <param name="g">Una Universidad</param>
        /// <param name="i">un Profesor</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// una universidad sera igual a una clase si un profesor de la misma da la clase, retorna profesor o arroja excepcion
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="clase">una clase</param>
        /// <returns>Profesor</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor iUni in g.profesores)
            {
                if (iUni == clase)
                {
                    return iUni;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// retornará el primer Profesor que no pueda dar la clase
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="clase">una clase</param>
        /// <returns>Profesor</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor iUni in g.profesores)
            {
                if (iUni != clase)
                {
                    return iUni;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega un alumno a la universidad si este no se encuentra en la misma, sino arroja una excepcion
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="a">un alumno</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }

        /// <summary>
        /// Agrega una clase generando una nueva jornada de la misma y le carga un profesor que de la misma y los alumnos que la cursan
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="clase">una clase</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada;
            foreach (Profesor i in g.profesores)
            {
                if (i == clase)
                {
                    nuevaJornada = new Jornada(clase, i);
                    foreach (Alumno a in g.alumnos)
                    {
                        if (a == clase)
                        {
                            nuevaJornada += a;
                        }
                    }
                    g.jornada.Add(nuevaJornada);
                    break;
                }
            }
            return g;
        }

        /// <summary>
        /// Agrega profesores a la Universidad si estos no estan ya cargados
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="i">un profesor</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas
        /// </summary>
        /// <param name="gim"></param>
        /// <returns>bool</returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> serializa = new Xml<Universidad>();
            serializa.Guardar("Universidad.xml", gim);
            return true;
        }

        /// <summary>
        /// retornará una Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns>Universidad</returns>
        public static Universidad Leer() 
        {
            Universidad gim = new Universidad();
            Xml<Universidad> deserializa = new Xml<Universidad>();
            deserializa.Guardar("Universidad.xml", gim);
            return gim;
        }
    }

}

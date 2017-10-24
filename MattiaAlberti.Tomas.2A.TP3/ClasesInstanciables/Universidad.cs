using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
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
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor iUni in g.profesores)
            {
                if (iUni == i)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
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

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }
    }
}

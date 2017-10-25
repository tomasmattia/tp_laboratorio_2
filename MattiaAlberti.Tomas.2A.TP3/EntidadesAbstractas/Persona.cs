using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero };
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (ValidarNombreApellido(value) != "nulo")
                {
                    this._apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set
            {
                if (value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                {
                    this._nacionalidad = value;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (ValidarNombreApellido(value) != "nulo")
                {
                    this._nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public Persona()
        {
            this._apellido = " ";
            this._dni = 0;
            this._nacionalidad = ENacionalidad.Argentino;
            this._nombre = " ";
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre;
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato > 0 && dato < 90000000))
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato > 89999999)
            {
                return dato;
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        private string ValidarNombreApellido(string dato)
        {
            if (dato.All(c => Char.IsLetter(c) || c == ' '))
            {
                return dato;
            }
            else
            {
                return "nulo";
            }
        }
    }
}

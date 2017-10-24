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
                int dniValido;
                int.TryParse(value, out dniValido);
                this._dni = ValidarDni(this.Nacionalidad, dniValido);
            }
        }

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            if (nacionalidad != ENacionalidad.Argentino || nacionalidad != ENacionalidad.Extranjero)
            {
                throw new NacionalidadInvalidaException();
            }
            this._nacionalidad = nacionalidad;
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
            if ((nacionalidad == ENacionalidad.Argentino && (dato > 1 && dato < 89999999)) || nacionalidad == ENacionalidad.Extranjero && dato > 89999999)
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
            int datoInt;
            if (int.TryParse(dato, out datoInt))
            {
                return ValidarDni(nacionalidad, datoInt);
            }
            else
            {
                throw new DniInvalidoException();
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {

        public enum ENacionalidad { Argentino, Extranjero }

        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        

        public string Apellido
        {
            get { return _apellido; }
            set { this._apellido=value; }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get
            { return this._nacionalidad; }
            set
            { this._nacionalidad = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }
        public string StringToDNI
        {
            set { this._dni = ValidarDni(this._nacionalidad,value); }
        }


        public Persona() : this("","","",ENacionalidad.Argentino)
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this(nombre, apellido, 1, nacionalidad)
        {
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,dni.ToString(),nacionalidad)
        {
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Devuelve un string con los datos de la persona
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + Apellido + ", " + Nombre + "\nNACIONALIDAD: " + Nacionalidad;
        }

        /// <summary>
        /// Realiza un tryparse al string y de pasar lo pasa como parametro a validarDni, caso contrario arroja una excepcion
        /// </summary>
        /// <param name="nacionalidad">una nacionalidad</param>
        /// <param name="dato">un dni</param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoParse;
            if (int.TryParse(dato, out datoParse))
            {
                return (ValidarDni(nacionalidad, datoParse));
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        ///  validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. Caso contrario, se lanzará la excepción DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
            {
                throw new DniInvalidoException("DNI INVALIDO", new NacionalidadInvalidaException("LA NACIONALIDAD NO COINCIDE CON EL DNI"));
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato <= 90000000)
            {
                throw new NacionalidadInvalidaException("LA NACIONALIDAD NO COINCIDE CON EL DNI");
            }
            return dato;
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato">un nombre</param>
        /// <returns>string</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (dato.All(c => Char.IsLetter(c) || c == ' '))
            {
                return dato;
            }
            return null;
        }
    }


}

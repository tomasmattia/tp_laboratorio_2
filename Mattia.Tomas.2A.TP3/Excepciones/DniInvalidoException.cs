using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        protected static string mensajeBase = "El dni es invalido";
        public DniInvalidoException() : base()
        {

        }
        public DniInvalidoException(Exception e) : this(DniInvalidoException.mensajeBase, e)
        {

        }
        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }
    }

}

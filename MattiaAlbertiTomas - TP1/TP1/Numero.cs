using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Numero
    {
        private double _numero;

        /// <summary>
        /// Constructor de un Objeto Numero que no recibe parametros llama al constructor con parametro double pasandole el numero 0
        /// </summary>
        public Numero():this(numero:0)
        {
        }

        /// <summary>
        /// Constructor de un Objeto Numero pasandole un string como parametro llama a SetNumero para establecer el valor pasandole el string 
        /// </summary>
        /// <param name="numeroString"></param>
        public Numero(string numeroString)
        {
            SetNumero(numeroString);
        }

        /// <summary>
        /// Constructor de un Objeto Numero pasandole un double como parametro llama al constructor con parametro string pasandole el numero convertido a string
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) : this(numeroString: numero.ToString())
        {
        }

        /// <summary>
        /// Retorva el valor _numero del objeto 
        /// </summary>
        /// <returns>El valor _numero del objeto</returns>
        public double GetNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// Recibe el numero en un string, lo valida y establece el valor de la propiedad _numero del objeto
        /// </summary>
        /// <param name="numeroString">String con un numero</param>
        private void SetNumero(string numeroString)
        {
            _numero = Numero.ValidarNumero(numeroString);
        }

        /// <summary>
        /// Recibe el numero en un string y valida que sea un valor parseable y lo devuelve, sino retorna 0
        /// </summary>
        /// <param name="numeroString">String con un numero</param>
        /// <returns></returns>
        static private double ValidarNumero(string numeroString)
        {
            if (!double.TryParse(numeroString, out double valorRetorno))
            {
                valorRetorno = 0;
            }
            return valorRetorno;
        }
    }
}

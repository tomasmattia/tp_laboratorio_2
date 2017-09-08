using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    class Numero
    {
        private double _numero;

        public Numero()
        {
            this._numero = 0;
        }

        public Numero(string numeroString)
        {
            this.SetNumero(numeroString);
        }

        public Numero(double numero):this(numeroString:numero.ToString())
        {
        }

        public double GetNumero()
        {
            return this._numero;
        }

        private void SetNumero(string numeroString)
        {
            this._numero = Numero.ValidarNumero(numeroString);
        }

        static private double ValidarNumero(string numeroString)
        {
            if (double.TryParse(numeroString, out double valorRetorno))
            {
            }
            else
            {
                valorRetorno = 0;
            }
            return valorRetorno;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Calculadora
    {
        /// <summary>
        /// Recibe objetos tipo numero y un string que determina que operacion se va a realizar entre ambos.
        /// </summary>
        /// <param name="numero1">Objeto tipo numero</param>
        /// <param name="numero2">Objeto tipo numero</param>
        /// <param name="operador">String con operador a realizar</param>
        /// <returns></returns>
        static public double Operar(Numero numero1, Numero numero2, string operador)
        {
            operador = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    return numero1.GetNumero() + numero2.GetNumero();
                case "-":
                    return numero1.GetNumero() - numero2.GetNumero();
                case "*":
                    return numero1.GetNumero() * numero2.GetNumero();
                case "/":
                    if (numero2.GetNumero() == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return numero1.GetNumero() / numero2.GetNumero();
                    }
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Recibe el string que contiene al operador y valida que sea un operador valido, caso contrario por defecto devuelve "+"
        /// </summary>
        /// <param name="operador">String con operador a realizar</param>
        /// <returns></returns>
        static public string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "+":
                    return "+";
                case "-":
                    return "-";
                case "*":
                    return "*";
                case "/":
                    return "/";
                default:
                    return "+";
            }
        }
    }
}

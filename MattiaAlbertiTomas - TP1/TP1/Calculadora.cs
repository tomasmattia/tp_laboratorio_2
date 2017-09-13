using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Calculadora
    {
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
                    if (numero2.GetNumero() <= 0)
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

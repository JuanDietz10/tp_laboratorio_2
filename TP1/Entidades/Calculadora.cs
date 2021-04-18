using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double ret = 0;

            if (num1 != null && num2 != null)
            {
                string opcion = String.Empty;

                if (operador.Length != 0)
                {
                    opcion = Calculadora.ValidarOperador(operador[0]);
                }
                else
                {
                    opcion = "+";
                }

                switch (opcion)
                {
                    case "+":
                        ret = num1 + num2;
                        break;

                    case "-":
                        ret = num1 - num2;
                        break;

                    case "/":
                        ret = num1 / num2;
                        break;

                    case "*":
                        ret = num1 * num2;
                        break;

                    default:
                        break;
                }
            }

            return ret;
        }

        private static string ValidarOperador(char operador)
        {
            string ret = String.Empty;

            if (!(operador == '+' || operador == '-' || operador == '/' || operador == '*'))
            {
                operador = '+';
            }

            ret = operador.ToString();

            return ret;
        }
    }
}

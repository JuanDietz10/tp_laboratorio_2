using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operacion indicada entre dos operandos
        /// </summary>
        /// <param name="num1">Operando 1</param>
        /// <param name="num2">Operando 2</param>
        /// <param name="operador">Operador</param>
        /// <returns></returns>
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

        /// <summary>
        /// Se valida que el operador ingresado sea válido ('+', '-', '/' o '*'), en caso de no serlo se retorna "+"
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns></returns>
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

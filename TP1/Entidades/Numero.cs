using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Inicializa al atributo numero con el valor 0 por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Inicializa al atributo numero con el contenido de la variable que se recibe por valor
        /// </summary>
        /// <param name="numero">Variable que recibe por valor un dato numerico</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Inicializa al atributo numero, pasando el contenido de strNumero por valor a la propiedad SetNumero
        /// </summary>
        /// <param name="strNumero">Variable que recibe por valor un dato de tipo string</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Propiedad que valida y setea un valor en el atributo numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                if (value.Length < 16) //Cantidad máxima de digitos de un tipo double
                {
                    this.numero = ValidarNumero(value); 
                }
                
            }
        }

        /// <summary>
        /// Valida que la cadena de tipo string que se recibe por valor pueda ser convertida a un tipo numerico
        /// y luego la retorna en tipo numerico double.
        /// En caso de no poder, retorna 0
        /// </summary>
        /// <param name="strNumero">Variable que recibe por valor un dato de tipo string</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double ret = 0;

            double.TryParse(strNumero, out ret);

            return ret;
        }

        /// <summary>
        /// Valida si la cadena ingresada corresponde a un número binario
        /// En caso positivo retorna true, sino, false
        /// </summary>
        /// <param name="binario">Variable que recibe por valor un dato de tipo string</param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            bool ret = true;

            foreach (char item in binario.ToCharArray())
            {
                if (item != '0' && item != '1')
                {
                    ret = false;
                }
            }

            return ret;
        }

        ///// <summary>
        ///// Valida que el numero que se ingresa sea binario y que se pueda convertir a un entero sin signo
        ///// En caso positivo retorna la conversion de ese numero a decimal en tipo string, sino, devuelve que es inválido
        ///// </summary>
        ///// <param name="binario">Variable que recibe por valor un dato de tipo string</param>
        ///// <returns></returns>
        //public static string BinarioDecimal2(string binario) //Solo puedo pasarle un numero binario de 10 bits
        //{
        //    string ret = String.Empty;

        //    uint aux = 0;
        //    uint numero = 0;

        //    if (EsBinario(binario) && uint.TryParse(binario, out aux))
        //    {
        //        for (int i = 0; i < binario.Length; i++)
        //        {
        //            if ((aux / (uint)Math.Pow(10, i)) % 2 == 1)
        //            {
        //                numero += (uint)Math.Pow(2, i);
        //            }
        //        }

        //        ret = numero.ToString();
        //    }
        //    else
        //    {
        //        ret = "Valor inválido";
        //    }

        //    return ret;
        //}

        /// <summary>
        /// Valida que el numero que se ingresa sea binario y que se pueda convertir a un entero sin signo
        /// En caso positivo retorna la conversion de ese numero a decimal en tipo string, sino, devuelve que es inválido
        /// </summary>
        /// <param name="binario">Variable que recibe por valor un dato de tipo string</param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string ret = String.Empty;

            uint aux = 0;
            uint numero = 0;

            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if (uint.TryParse(binario[i].ToString(), out aux))
                    {
                        numero += aux * (uint)Math.Pow(2, binario.Length - 1 - i);
                    }
                    else
                    {
                        ret = "Valor inválido";
                    }
                }

                ret = numero.ToString();
            }
            else
            {
                ret = "Valor inválido";
            }

            return ret;
        }

        /// <summary>
        /// Valida que el numero que se ingresa se pueda convertir a un entero sin signo
        /// En caso positivo retorna la conversion de ese numero a binario en tipo string, sino, devuelve que es inválido
        /// </summary>
        /// <param name="numero">Variable que recibe por valor un dato numérico</param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string ret = "Valor inválido";

            if ((numero = Math.Truncate(Math.Abs(numero))) <= 4294967295) //Mayor numero decimal entero que puede ser guardado en una variable tipo uint (32 bits)
            {
                uint cociente = (uint)numero;
                uint divisor = 2;
                uint reminder = 0;

                if (cociente == 0)
                {
                    ret = "0";
                }
                else if (cociente == 1)
                {
                    ret = "1";
                }
                else
                {
                    ret = String.Empty;

                    do
                    {
                        reminder = cociente % 2;
                        ret = reminder + ret;
                        cociente /= divisor;
                    } while (cociente != 1);

                    ret = cociente + ret;
                }
            }

            return ret;
        }

        /// <summary>
        /// Valida que el numero que se ingresa se pueda convertir a un tipo numérico
        /// En caso positivo retorna la conversion de ese numero a binario en tipo string, sino, devuelve que es inválido
        /// </summary>
        /// <param name="numero">Variable que recibe por valor un dato tipo string</param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string ret = String.Empty;
            double aux;

            if (double.TryParse(numero, out aux))
            {
                ret = DecimalBinario(aux);
            }
            else
            {
                ret = "Valor inválido";
            }

            return ret;
        }

        /// <summary>
        /// Suma los atributos de dos objetos y retorna el resultado en tipo numérico double
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double ret = 0;

            if (n1 != null && n2 != null)
            {
                 ret = n1.numero + n2.numero;
            }

            return ret;
        }

        /// <summary>
        /// Resta los atributos de dos objetos y retorna el resultado en tipo numérico double
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double ret = 0;

            if (n1 != null && n2 != null)
            {
                ret = n1.numero - n2.numero;
            }

            return ret;
        }

        /// <summary>
        /// Divide los atributos de dos objetos y retorna el resultado en tipo numérico double
        /// En caso de que el divisor sea 0, retornara el double.MinValue
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double ret = 0;

            if (n1 != null && n2 != null)
            {
                if (n2.numero != 0)
                {
                    ret = n1.numero / n2.numero;
                }
                else
                {
                    ret = double.MinValue;
                }
            }

            return ret;
        }

        /// <summary>
        /// Multiplica los atributos de dos objetos y retorna el resultado en tipo numérico double
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double ret = 0;

            if (n1 != null && n2 != null)
            {
                ret = n1.numero * n2.numero;
            }

            return ret;
        }
    }
}

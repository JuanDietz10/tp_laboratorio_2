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

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        private double ValidarNumero(string strNumero)
        {
            double ret = 0;

            double.TryParse(strNumero, out ret);

            return ret;
        }

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

        public static string BinarioDecimal(string binario)
        {
            string ret = String.Empty;

            uint aux = 0;
            uint numero = 0;

            if (EsBinario(binario) && uint.TryParse(binario, out aux))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if ((aux / (uint)Math.Pow(10, i)) % 2 == 1)
                    {
                        numero += (uint)Math.Pow(2, i);
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

        public static string DecimalBinario(double numero)
        {
            string ret = "Valor inválido";

            if (Math.Abs(numero) <= 4294967295)
            {
                uint cociente = (uint)Math.Abs(numero);
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

        public static double operator +(Numero n1, Numero n2)
        {
            double ret = 0;

            if (n1 != null && n2 != null)
            {
                 ret = n1.numero + n2.numero;
            }

            return ret;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double ret = 0;

            if (n1 != null && n2 != null)
            {
                ret = n1.numero - n2.numero;
            }

            return ret;
        }

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

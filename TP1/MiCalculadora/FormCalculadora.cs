using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Limpia los campos de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Component item in this.pnlComponents.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Text = String.Empty;
                }
                else if (item is Label)
                {
                    ((Label)item).Text = String.Empty;
                }
            }
        }

        /// <summary>
        /// Realiza una operacion matemática entre dos numeros
        /// y retorna el resultado en un tipo numérico double
        /// </summary>
        /// <param name="numero1">Operando 1</param>
        /// <param name="numero2">Operando 2</param>
        /// <param name="operador">Operador</param>
        /// <returns></returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            double ret = 0;

            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            ret = Calculadora.Operar(num1, num2, operador);

            return ret;
        }

        /// <summary>
        /// Realiza una operacion matemática (de ser posible) entre los dos numeros ingresados con el operador en los campos de texto
        /// y retorna el resultado en el Label Resultado
        /// También acomoda el tamaño de la fuente con respecto a la longitud del resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            byte resultadoLength;
            byte labelLength = 22;
            byte fontSize = 24;

            this.lblResultado.Text = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text)).ToString();

            resultadoLength = (byte)this.lblResultado.Text.Length;

            if (resultadoLength > 22)
            {
                labelLength = resultadoLength;
                fontSize = (byte)(-labelLength + 46); //Calcula aproximadamente la relación entre el tamaño de la fuente y la cantidad de caracteres

                this.lblResultado.Font = new Font("Microsoft Sans Serif", fontSize);
            }
            else
            {
                this.lblResultado.Font = new Font("Microsoft Sans Serif", 24);
            }
        }

        /// <summary>
        /// Cierra el formulario principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Seguro desea cerrar?", "Cerrando", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        /// <summary>
        /// Convierte a binario (de ser posible) el contenido del Label Resultado
        /// y retorna el resultado en el Label Resultado
        /// También acomoda el tamaño de la fuente con respecto a la longitud del resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvetirABinario_Click(object sender, EventArgs e)
        {
            byte resultadoLength;
            byte labelLength = 22;
            byte fontSize = 24;

            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);

            resultadoLength = (byte)this.lblResultado.Text.Length;

            if (resultadoLength > 22)
            {
                labelLength = resultadoLength;
                fontSize = (byte)(-labelLength + 46); //Calcula aproximadamente la relación entre el tamaño de la fuente y la cantidad de caracteres

                this.lblResultado.Font = new Font("Microsoft Sans Serif", fontSize);
            }
            else
            {
                this.lblResultado.Font = new Font("Microsoft Sans Serif", 24);
            }
        }

        /// <summary>
        /// Convierte a decimal (de ser posible) el contenido del Label Resultado
        /// y retorna el resultado en el Label Resultado
        /// También acomoda el tamaño de la fuente con respecto a la longitud del resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvetirADecimal_Click(object sender, EventArgs e)
        {
            byte resultadoLength;
            byte labelLength = 22;
            byte fontSize = 24;

            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);

            resultadoLength = (byte)this.lblResultado.Text.Length;

            if (resultadoLength > 22)
            {
                labelLength = resultadoLength;
                fontSize = (byte)(-labelLength + 46); //Calcula aproximadamente la relación entre el tamaño de la fuente y la cantidad de caracteres

                this.lblResultado.Font = new Font("Microsoft Sans Serif", fontSize);
            }
            else
            {
                this.lblResultado.Font = new Font("Microsoft Sans Serif", 24);
            }
        }
    }
}

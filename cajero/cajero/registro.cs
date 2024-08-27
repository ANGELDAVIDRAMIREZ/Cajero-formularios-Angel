using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cajero
{
    public partial class registro : Form
    {
        public registro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Form1 cancelar = new Form1();
            cancelar.Show();
            this.Hide();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            textBox5.MaxLength = 6;
            string currentText = textBox5.Text;


            for (int i = 0; i < currentText.Length; i++)
            {
                if (!char.IsDigit(currentText[i]))
                {

                    textBox5.Text = currentText.Remove(i, 1);

                    textBox5.SelectionStart = textBox5.Text.Length;
                    break;
                }
            }

        }

        private void registro_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string currentText = textBox4.Text;


            for (int i = 0; i < currentText.Length; i++)
            {
                if (!char.IsDigit(currentText[i]))
                {

                    textBox4.Text = currentText.Remove(i, 1);

                    textBox4.SelectionStart = textBox4.Text.Length;
                    break;
                }
            }
        }
    }
}

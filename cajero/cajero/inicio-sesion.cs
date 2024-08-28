using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cajero
{
    public partial class inicio_sesion : Form
    {
        public inicio_sesion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 cancelar = new Form1();
            cancelar.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 6;
            string currentText = textBox2.Text;


            for (int i = 0; i < currentText.Length; i++)
            {
                if (!char.IsDigit(currentText[i]))
                {
                    textBox2.Text = currentText.Remove(i, 1);

                    textBox2.SelectionStart = textBox2.Text.Length;
                    break;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string currentText = textBox1.Text;


            for (int i = 0; i < currentText.Length; i++)
            {
                if (!char.IsDigit(currentText[i]))
                {
                    textBox1.Text = currentText.Remove(i, 1);

                    textBox1.SelectionStart = textBox1.Text.Length;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Conexion = new SqlConnection("Server=ANGEL\\SQLEXPRESS; Database=Cajero; persist security info=True; Integrated security=True;");
            SqlCommand Realiza = new SqlCommand();
            Conexion.Open();
            Realiza.Connection = Conexion;
            string NumeroCuenta = textBox1.Text;
            string PIN = textBox2.Text;
            string cadena = "select * from registrarse where numero_cuenta='"+NumeroCuenta+"' ";
            SqlCommand comando = new SqlCommand(cadena, Conexion);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                if (registros["numero_cuenta"].ToString() == NumeroCuenta && registros["clave"].ToString() == PIN)
                {
                    MessageBox.Show("Se ingreso correctamente");
                }
            }
            else
            {
                MessageBox.Show("No se encontró ningún registro con los datos proporcionados.");
            }
        }
    }
    
}

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

        private void guardar_Click(object sender, EventArgs e)
        {
            Form1 guardar = new Form1();
            guardar.Show();
            this.Hide();

            try
            {
                SqlConnection Conexion = new SqlConnection("Server=ANGEL\\SQLEXPRESS; Database=Cajero; persist security info=True; Integrated security=True;");
                SqlCommand Realiza = new SqlCommand();
                Realiza.Connection = Conexion;
                Realiza.CommandText = "insert into registrarse (nombre,apellido,edad,tipo_documento,documento,clave) values(@nombre,@apellido,@edad,@tipo_documento,@documento,@clave)";
                Realiza.CommandType = System.Data.CommandType.Text;
                Realiza.Parameters.AddWithValue("@nombre", textBox1.Text);
                Realiza.Parameters.AddWithValue("@apellido", textBox2.Text);
                Realiza.Parameters.AddWithValue("@edad", textBox3.Text);
                Realiza.Parameters.AddWithValue("@tipo_documento", comboBox1.Text);
                Realiza.Parameters.AddWithValue("@documento", textBox4.Text);
                Realiza.Parameters.AddWithValue("@clave", textBox5.Text);
                Conexion.Open();
                Realiza.ExecuteNonQuery();
                string cadena = "select top 1 * from registrarse order by numero_cuenta desc ";
                SqlCommand comando = new SqlCommand(cadena, Conexion);
                SqlDataReader registros = comando.ExecuteReader();
                if (registros.Read()) 
                {
                    
                    string numeroDeCuenta = registros["numero_cuenta"].ToString();
                    MessageBox.Show($"Su número de cuenta es {numeroDeCuenta}", "Número de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string currentText = textBox3.Text;


            for (int i = 0; i < currentText.Length; i++)
            {
                if (!char.IsDigit(currentText[i]))
                {

                    textBox3.Text = currentText.Remove(i, 1);

                    textBox3.SelectionStart = textBox3.Text.Length;
                    break;
                }
            }
        }
    }
}

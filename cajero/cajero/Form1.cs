﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            registro Register = new registro();
            Register.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicio_sesion iniciar = new inicio_sesion();
            iniciar.Show();
            this.Hide();
        }
    }
}

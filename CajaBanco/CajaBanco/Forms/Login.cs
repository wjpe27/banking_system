using CajaBanco.Forms;
using CajaBanco.Forms.advertencias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaBanco
{
    public partial class Login : Form
    {
        IntegracionClientes.ClientesSoapClient client = new IntegracionClientes.ClientesSoapClient();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            GestorBaseDeDatos pep = new GestorBaseDeDatos();
            pep.LlamarCloner();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void UserTxt_Enter(object sender, EventArgs e)
        {
            if (UserTxt.Text == "Ingrese su usuario")
            {

                UserTxt.Text = "";
                UserTxt.ForeColor = Color.LightGray;

            }
        }

        private void UserTxt_Leave(object sender, EventArgs e)
        {
            if (UserTxt.Text == "")
            {

                UserTxt.Text = "Ingrese su usuario";
                UserTxt.ForeColor = Color.Black;

            }
        }

        private void PassTxt_Enter(object sender, EventArgs e)
        {
            if (PassTxt.Text == "Ingrese su contraseña")
            {   
                PassTxt.Text = "";
                PassTxt.ForeColor = Color.LightGray;
                PassTxt.UseSystemPasswordChar = true;
            }
        }

        private void PassTxt_Leave(object sender, EventArgs e)
        {
            if (PassTxt.Text == "")
            {
                PassTxt.Text = "Ingrese su contraseña";
                PassTxt.ForeColor = Color.Black;
                PassTxt.UseSystemPasswordChar = false;

            }
        }

        private void LoginBT_Click(object sender, EventArgs e)
        {

            string password, user;

            user = UserTxt.Text;
            password = PassTxt.Text;
            bool p = client.RevisarContraseña(user, password,"Anonimo",1);
            if (p == true)
            {

                Application.Run(new Home());
                Application.Exit();

            }
            

        }
    }
}

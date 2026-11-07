using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Windows
{
    public partial class Login : Form
    {
        GestionUsuarios gestion = new GestionUsuarios();
        private string usuarioConectado = "";
        public Login()
        {
            InitializeComponent();
        }

        public string GetUsuario()
        {
            return usuarioConectado;
        }
        private void button_entrar_Click(object sender, EventArgs e)
        {
            string nombre = textBox_usuario.Text.Trim();
            string password = textBox_password.Text;

            string error = ValidarCampos(nombre, password);
            if (error != "")
            {
                MessageBox.Show(error, "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (gestion.ComprobarLogin(nombre, password))
                {
                    usuarioConectado = nombre;
                    this.DialogResult = DialogResult.OK;
                    //Cierra el login y avisa al programa de que puede abrir el menu
                }

                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_password.Text = "";
                    textBox_password.Focus();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error al consultar la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        private void Login_Load(object sender, EventArgs e)
        {
            if (!gestion.Iniciar())
            {
                MessageBox.Show("No se encuentra la base de datos de usuarios. La aplicación se cerrará.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //comprobamos los datos escritos, parámetros de nombre y contraseña.
        //Devuelve ""si son validos, o el mensaje de error si no lo son.

        private string ValidarCampos(string nombre, string password)
        {
            if (nombre == "" || password == "")
                return "Escribe el usuario y la contraseña.";
            if (nombre.Contains("'") || password.Contains("'"))
                return "El usuario y la contraseña no pueden contener el caracter '";
            return "";
        }

        private void linkCambiarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CambiarPassword cc = new CambiarPassword(gestion);

            cc.ShowDialog(); //show dialog or form to change the password
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            gestion.Cerrar();
        }

        private void button_registrar_Click(object sender, EventArgs e)
        {
            RegistrarNuevoUsuario rnu = new RegistrarNuevoUsuario(gestion);
            if (rnu.ShowDialog() == DialogResult.OK)
            {
                textBox_usuario.Text = rnu.GetUsuarioRegistrado();
                textBox_password.Text = "";
                textBox_password.Focus();
            }
          
        }
    }
}

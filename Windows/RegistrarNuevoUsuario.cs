using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Windows
{
    public partial class RegistrarNuevoUsuario : Form
    {
        private GestionUsuarios gestion;
        public RegistrarNuevoUsuario(GestionUsuarios gestion)
        {
            InitializeComponent();
            this.gestion = gestion;
        }

        private bool CampoValido(string texto)
        {
            return texto != "" && !texto.Contains("'");
        }
        private void button_registrar_Click(object sender, EventArgs e)
        {
            string nombre = textBox_usuario.Text.Trim();
            string password = textBox_NuevaPassword.Text;
            string recuperacion = textBox_recuperacion.Text;

            if (!CampoValido(nombre) || !CampoValido(password) || !CampoValido(recuperacion))
            {
                MessageBox.Show("Rellena el usuario, la contraseña y la palabra de recuperación (sin el caracter ').", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int resultado = gestion.Registrar(nombre, password, recuperacion);

                if (resultado == 0)
                {
                    MessageBox.Show("Usuario registrado correctamente. Ya puedes entrar.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usuarioRegistrado = nombre;
                    this.DialogResult = DialogResult.OK;
                    //cierra el registro de usuario y vuelve al login
                }

                else if (resultado == -1)
                    MessageBox.Show("Ya existe un usuario con ese nombre. Elige otro.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("No se ha podido registrar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (recuperacion == "" || recuperacion.Contains("'"))
            {
                MessageBox.Show("Escribe una palabra de recuperacion (sin el caracter ').", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

            private string usuarioRegistrado = "";

        //devuelve el nombre del usuario que se acaba de registrar.
        public string GetUsuarioRegistrado()
        {
            return usuarioRegistrado;
        }

        }
    }


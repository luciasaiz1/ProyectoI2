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


namespace Windows
{
    public partial class RegistrarNuevoUsuario : Form
    {
        // ATRIBUTOS
        private Estilo estilo = new Estilo();
        private GestionUsuarios gestion;
        private string usuarioRegistrado = "";

        // CONSTRUCTOR
        public RegistrarNuevoUsuario(GestionUsuarios gestion)
        {
            InitializeComponent();
            this.gestion = gestion;
        }
        // MÉTODOS
        // Comunicación entre forms
        public string GetUsuarioRegistrado()
        {
            return usuarioRegistrado;
        }

        // Estética
        private void RegistrarNuevoUsuario_Paint(object sender, PaintEventArgs e)
        {

            estilo.PintarFondo(e.Graphics, this.ClientRectangle);
        }

        // Comprobar si los campos son válidos
        private bool CampoValido(string texto)
        {
            return texto != "" && !texto.Contains("'");
        }
        // Registrar nuevo usuario
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
                    this.DialogResult = DialogResult.OK; // Cierra el formulario y devuelve OK
                }
                else if (resultado == -1)
                {
                    MessageBox.Show("Ya existe un usuario con ese nombre. Elige otro.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}


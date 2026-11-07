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
    public partial class CambiarPassword: Form
    {
        private GestionUsuarios gestion;
        public CambiarPassword(GestionUsuarios gestion)
        {
          InitializeComponent();
            this.gestion = gestion;
        }

        private void button_cambiarpassword_Click(object sender, EventArgs e)
        {
            string nombre = textBox_usuario2.Text.Trim();
            string recuperacion = textBox_palabra.Text;
            string nueva = textBox_nuevapassword.Text;

            if (nombre == "" || recuperacion == "" || nueva == "")
            {
                MessageBox.Show("Rellena los tres campos.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nombre.Contains("'") || recuperacion.Contains("'") || nueva.Contains("'"))
            {
                MessageBox.Show("Los campos no pueden contener el caracter '", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (gestion.CambiarPassword(nombre, recuperacion, nueva))
                {

                    MessageBox.Show("Contraseña cambiada correctamente. Ya puedes entrar.", "Recuperar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El usuario o la palabra de recuperacion no son correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        }
    }


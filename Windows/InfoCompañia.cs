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
    public partial class InfoCompañia : Form
    {
        string rutaLogo = "";
        string compañia;
        string telefono;
        string correo;

        public void SetInfo(string nombre, string tel, string mail)
        {
            this.compañia = nombre;
            this.telefono = tel;
            this.correo = mail;
        }

        public InfoCompañia()
        {
            InitializeComponent();
            label_compañia.Text = this.compañia;
            label_telefono.Text = this.telefono;
            label_correo.Text = this.correo;
        }


        private void button_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscador = new OpenFileDialog();
            buscador.Title = "Selecciona el logo de la compañía";
            buscador.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                rutaLogo = buscador.FileName; // Guarda la ruta del archivo elegido
                pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen para que no se corte
                pictureBox_logo.ImageLocation = rutaLogo; // La muestra automáticamente en el PictureBox
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;
using System.IO;

namespace Windows
{
    public partial class InfoCompañia : Form
    {
        private FlightPlan plan;
        string rutaLogo = "";
        string compañia;
        string telefono;
        string correo;
        public bool CambioGuardado;
        public InfoCompañia(FlightPlan plan) : this()
        {
            this.plan = plan;
        }

        public void SetInfo(string nombre, string tel, string mail)
        {
            this.compañia = nombre;
            this.telefono = tel;
            this.correo = mail;

            label_compañia.Text = this.compañia;
            label_telefono.Text = this.telefono;
            label_correo.Text = this.correo;

            CargarLogoGuardado(this.compañia);
        }
        public string GetCompañia()
        {
            return compañia;
        }
        public InfoCompañia()
        {
            InitializeComponent();
            button_logo.Text = "Cambiar logo";
        }
        private void CargarLogoGuardado(string nombreCompañia)
        {
            GestionCompañias gestion = new GestionCompañias();

            if (!gestion.Iniciar())
                return;

            try
            {
                DataTable datos = gestion.GetCompañias();

                foreach (DataRow fila in datos.Rows)
                {
                    if (fila["nombre"].ToString() != nombreCompañia)
                        continue;

                    string rutaGuardada =fila["logo"].ToString();

                    if (!string.IsNullOrWhiteSpace(rutaGuardada) &&
                        File.Exists(rutaGuardada))
                    {
                        rutaLogo = rutaGuardada;
                        pictureBox_logo.SizeMode =PictureBoxSizeMode.Zoom;
                        pictureBox_logo.ImageLocation = rutaLogo;
                    }

                    break;
                }
            }
            finally
            {
                gestion.Cerrar();
            }
        }

        private void button_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscador = new OpenFileDialog();

            buscador.Title = "Selecciona el logo de la compañía";
            buscador.Filter ="Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (buscador.ShowDialog() != DialogResult.OK)
                return;

            rutaLogo = buscador.FileName;

            pictureBox_logo.SizeMode =PictureBoxSizeMode.Zoom;
            pictureBox_logo.ImageLocation = rutaLogo;

            GestionCompañias gestion = new GestionCompañias();

            if (!gestion.Iniciar())
            {
                MessageBox.Show("No se ha podido abrir la base de datos.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            try
            {
                bool guardado = gestion.CambiarInfo(compañia,compañia,telefono,correo,rutaLogo);

                if (!guardado)
                {
                    MessageBox.Show("No se ha podido guardar el logo.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            finally
            {
                gestion.Cerrar();
            }
        }

        private void button_cambiar_Click(object sender, EventArgs e)
        {
            CambioGuardado = false;
            string nombreAnterior = compañia;

            InfoCompañiaCambiar c = new InfoCompañiaCambiar();
            c.SetInfo(compañia, telefono, correo);

            if (c.ShowDialog() != DialogResult.OK)
                return;

            (compañia, telefono, correo) = c.GetInfo();

            GestionCompañias gestion = new GestionCompañias();

            if (!gestion.Iniciar())
            {
                MessageBox.Show(
                    "No se ha podido abrir la base de datos de compañías.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                bool actualizado = gestion.CambiarInfo(nombreAnterior,compañia,telefono,correo,rutaLogo);

                if (!actualizado)
                {
                    MessageBox.Show("No se ha podido actualizar la información de la compañía.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                    return;
                }

                // Actualiza también el FlightPlan asociado
                if (plan != null)
                    plan.SetCompany(compañia);

                label_compañia.Text = compañia;
                label_telefono.Text = telefono;
                label_correo.Text = correo;

                CambioGuardado = true;
                gestion.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la información de la compañía: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

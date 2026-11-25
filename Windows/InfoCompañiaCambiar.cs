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
    public partial class InfoCompañiaCambiar : Form
    {
        string compañia;
        string telefono;
        string correo;

        public void SetInfo(string nombre, string tel, string mail)
        {
            this.compañia = nombre;
            this.telefono = tel;
            this.correo = mail;

            textBox_compañia.Text = this.compañia;
            textBox_telefono.Text = this.telefono;
            textBox_correo.Text = this.correo;
        }
        public (string, string, string) GetInfo()
        {
            return (this.compañia, this.telefono, this.correo);
        }
        public InfoCompañiaCambiar()
        {
            InitializeComponent();

            if (this.compañia != "" && this.compañia != null)
                textBox_compañia.Text = this.compañia;

            if (this.telefono != "" && this.telefono != null)
                textBox_telefono.Text = this.telefono;

            if (this.correo != "" && this.correo != null)
                textBox_correo.Text = this.correo;
        }

        private void button_cambiar_Click(object sender, EventArgs e)
        {
            compañia = textBox_compañia.Text;
            telefono = textBox_telefono.Text;
            correo = textBox_correo.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

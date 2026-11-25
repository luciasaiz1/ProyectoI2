using FlightLib;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Windows
{
    public partial class DatosCompañias : Form
    {
        private Estilo estilo = new Estilo();
        private FlightPlanList listaVuelos;
        public bool CambioGuardado;

        public DatosCompañias(FlightPlanList vuelos)
        {
            InitializeComponent();

            this.listaVuelos = vuelos;

            dataGridView_compañias.ReadOnly = true;
            dataGridView_compañias.AllowUserToAddRows = false;
            dataGridView_compañias.AutoGenerateColumns = true;
            dataGridView_compañias.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_compañias.SelectionMode =DataGridViewSelectionMode.FullRowSelect;
            dataGridView_compañias.MultiSelect = false;

            button_añadir.Click += button_añadir_Click;
            button_borrar_datos.Click += button_borrar_datos_Click;
            dataGridView_compañias.CellContentClick -= dataGridView_compañias_CellClick;
            dataGridView_compañias.CellClick +=dataGridView_compañias_CellClick;

            CargarCompañias();
        }

        private void CargarCompañias()
        {
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
                DataTable datos = gestion.GetCompañias();

                dataGridView_compañias.DataSource = datos;

                if (dataGridView_compañias.Columns.Contains("nombre"))
                    dataGridView_compañias.Columns["nombre"].HeaderText ="Compañía";

                if (dataGridView_compañias.Columns.Contains("telefono"))
                    dataGridView_compañias.Columns["telefono"].HeaderText ="Teléfono";

                if (dataGridView_compañias.Columns.Contains("correo"))
                    dataGridView_compañias.Columns["correo"].HeaderText ="Correo";

                // La ruta del logo no es necesario mostrarla en la tabla.
                if (dataGridView_compañias.Columns.Contains("logo"))
                    dataGridView_compañias.Columns["logo"].Visible = false;
                gestion.Cerrar();
            }
            catch
            {
                MessageBox.Show("Error al cargar las compañías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_añadir_Click(object sender, EventArgs e)
        {
            InfoCompañiaCambiar icc =new InfoCompañiaCambiar();

            if (icc.ShowDialog() != DialogResult.OK)
                return;

            (string nombre, string telefono, string correo) =icc.GetInfo();

            nombre = (nombre ?? "").Trim();
            telefono = (telefono ?? "").Trim();
            correo = (correo ?? "").Trim();

            if (nombre == "")
            {
                MessageBox.Show("El nombre de la compañía es obligatorio.","Datos incompletos",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                return;
            }

            GestionCompañias gestion = new GestionCompañias();

            if (!gestion.Iniciar())
            {
                MessageBox.Show("No se ha podido abrir la base de datos de compañías.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            try
            {
                int resultado = gestion.RegistrarCompañia(nombre,telefono,correo,"");

                if (resultado == 0)
                {
                    MessageBox.Show("La compañía se ha añadido correctamente.","Compañía añadida",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    CargarCompañias();
                }
                else if (resultado == -1)
                {
                    MessageBox.Show("Ya existe una compañía con ese nombre.","Compañía duplicada",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No se ha podido añadir la compañía.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            finally
            {
                gestion.Cerrar();
            }
        }
        private void dataGridView_compañias_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =dataGridView_compañias.Rows[e.RowIndex];

            string nombreCompañia =Convert.ToString(fila.Cells["nombre"].Value);
            string telefono =Convert.ToString(fila.Cells["telefono"].Value);
            string correo =Convert.ToString(fila.Cells["correo"].Value);

            // Valores predeterminados usados también en InfoVuelo
            if (string.IsNullOrWhiteSpace(telefono))
                telefono = "123 456 789";

            if (string.IsNullOrWhiteSpace(correo))
                correo = nombreCompañia + "@gmail.com";

            InfoCompañia formulario =new InfoCompañia();

            formulario.SetInfo(nombreCompañia,telefono,correo);

            formulario.ShowDialog();

            if (formulario.CambioGuardado)
            {
                string nombreNuevo =
                    formulario.GetCompañia();

                for (int i = 0; i < listaVuelos.GetCount(); i++)
                {
                    FlightPlan vuelo =
                        listaVuelos.GetFlightPlan(i);

                    if (vuelo.GetCompany() == nombreCompañia)
                        vuelo.SetCompany(nombreNuevo);
                }
            }

            CargarCompañias();
        }

        private void button_borrar_datos_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que quieres borrar toda la información de las compañías?","Confirmar borrado",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            GestionCompañias gestion = new GestionCompañias();

            if (!gestion.Iniciar())
            {
                MessageBox.Show(
                    "No se ha podido abrir la base de datos de compañías.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            try
            {
                if (gestion.BorrarTodasLasCompañias())
                {
                    MessageBox.Show(
                        "Se ha borrado toda la información.","Base de datos vacía",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    CargarCompañias();
                }
                else
                {
                    MessageBox.Show("No se ha podido borrar la información.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            finally
            {
                gestion.Cerrar();
            }
        }

        private void DatosCompañias_Paint(
            object sender,
            PaintEventArgs e)
        {
            estilo.PintarFondo(e.Graphics, this.ClientRectangle);
        }
    }
}
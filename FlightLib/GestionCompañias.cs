using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class GestionCompañias
    {
        // ATRIBUTO
        private SQLiteConnection cnx;

        // Abrimos la base de datos de las compañías
        public bool Iniciar()
        {
            string rutaDB = "..\\..\\companias_info.db";

            if (!File.Exists(rutaDB))
            {
                Debug.WriteLine("NO ENCUENTRA EL ARCHIVO EN: " + Path.GetFullPath(rutaDB));
                return false;
            }

            try
            {
                cnx = new SQLiteConnection("Data Source=" + rutaDB);
                cnx.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR SQLITE: " + ex.Message);
                return false;
            }
        }



        public void Cerrar()
        {
            if (cnx != null)
            {
                cnx.Close();
            }
        }

        // Comprueba si ya existe una compañía con ese nombre
        public bool ExisteCompañia(string nombre)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM compañias WHERE nombre = '" + nombre + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt.Rows.Count == 1;
        }

        // Obtener todas las compañías
        public DataTable GetCompañias()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM compañias";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }

        // Registrar una compañía nueva (incluyendo la ruta de su logo)
        // Permite dejar hasta 3 campos vacíos, pero nunca los 4
        public int RegistrarCompañia(string nombre, string telefono, string mail, string rutaLogo)
        {
            // 1. Comprobamos que no estén todos vacíos
            if (nombre == "" && telefono == "" && mail == "" && rutaLogo == "")
                return -3;

            // 2. Comprobamos si ya existe (si se ha introducido un nombre)
            if (nombre != "" && ExisteCompañia(nombre))
                return -1;

            // 3. Copiamos la imagen a una carpeta local del proyecto ("..\..\logos\") para que no se pierda
            string rutaGuardada = "";
            if (rutaLogo != "" && File.Exists(rutaLogo))
            {
                string carpetaLogos = "..\\..\\logos\\";
                if (!Directory.Exists(carpetaLogos))
                    Directory.CreateDirectory(carpetaLogos);

                string nombreArchivo = Path.GetFileName(rutaLogo);
                rutaGuardada = carpetaLogos + nombreArchivo;
                File.Copy(rutaLogo, rutaGuardada, true); // Copia la foto y sobrescribe si ya existía
            }

            string sql = "INSERT INTO compañias VALUES('" + nombre + "','" + telefono + "','" + mail + "','" + rutaGuardada + "')";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int filas = command.ExecuteNonQuery();

            if (filas == 1)
                return 0;
            else
                return -2;
        }

        // Modifica uno, varios o todos los campos (incluido el logo)
        // Si un parámetro "nuevo..." se pasa vacío (""), conserva el dato que ya tenía la base de datos.
        public bool CambiarInfo(string nombreActual, string nuevoNombre, string nuevoTelefono, string nuevoCorreo, string nuevoLogo)
        {
            // 1. Buscamos los datos actuales de esa compañía
            DataTable dt = new DataTable();
            string sqlBuscar = "SELECT * FROM compañias WHERE nombre = '" + nombreActual + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sqlBuscar, cnx);
            adp.Fill(dt);

            if (dt.Rows.Count != 1)
                return false;

            // 2. Si algún campo nuevo viene vacío, mantenemos el que ya estaba guardado
            if (nuevoNombre == "")
                nuevoNombre = dt.Rows[0][0].ToString();

            if (nuevoTelefono == "")
                nuevoTelefono = dt.Rows[0][1].ToString();

            if (nuevoCorreo == "")
                nuevoCorreo = dt.Rows[0][2].ToString();

            string rutaLogoFinal = dt.Rows[0][3].ToString(); // Por defecto mantenemos el logo anterior

            // Si el usuario eligió una imagen nueva en el form, la copiamos y actualizamos la ruta
            if (nuevoLogo != "" && File.Exists(nuevoLogo))
            {
                string carpetaLogos = "..\\..\\logos\\";
                if (!Directory.Exists(carpetaLogos))
                    Directory.CreateDirectory(carpetaLogos);

                string nombreArchivo = Path.GetFileName(nuevoLogo);
                rutaLogoFinal = carpetaLogos + nombreArchivo;
                File.Copy(nuevoLogo, rutaLogoFinal, true);
            }

            // Si quiere cambiar el nombre a otro distinto, comprobamos que el nuevo nombre no esté ya pillado
            if (nuevoNombre != nombreActual && ExisteCompañia(nuevoNombre))
                return false;

            // 3. Actualizamos la fila en la base de datos
            string sql = "UPDATE compañias SET nombre = '" + nuevoNombre + "', telefono = '" + nuevoTelefono + "', correo = '" + nuevoCorreo + "', logo = '" + rutaLogoFinal + "' WHERE nombre = '" + nombreActual + "'";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int filas = command.ExecuteNonQuery();

            return filas == 1;
        }
    }
}
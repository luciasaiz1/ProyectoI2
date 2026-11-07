using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;

namespace FlightLib
{
    public class GestionUsuarios
    {
        private SQLiteConnection cnx;

        //abrimos la base de datos de los usuarios.
        //Devuelve true si se ha podido abrir y false si el fichero no existe o hay un error.

        public bool Iniciar()
        {
            if (!File.Exists("usuarios.db"))
                return false; //SQLite crearia una base vacía sin avisarnos; lo comprobaremos antes
            try

            {
                cnx = new SQLiteConnection("Data Source=usuarios.db");
                cnx.Open();
                return true;
            }
            catch (Exception)
            {
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

        //El siguiente metodo indicará si existe usuario con ese nombre;
        //Parametro: nombre del usuario. Devuelve true si existe
        public bool ExisteUsuario(string nombre)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM usuarios WHERE nombre = '" + nombre + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt.Rows.Count == 1;
        }

        //Comprobamos si el nombre y contraseña son correctos
        //devuelve true si coinciden con el usuario registrado

        public bool ComprobarLogin(string nombre, string password)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM usuarios WHERE nombre = '" + nombre + "' AND password = '" + password + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt.Rows.Count == 1;
        }

        //Registrar un usuario nuevo
        //Parametros: nombre, palabra de recuperacion y password, devuelve 0 si se ha registrado con exito, -1 si ya existe y -2 si ha habido un error
        public int Registrar(string nombre, string password, string recuperacion)
        {
            if (ExisteUsuario(nombre))
                return -1;

            string sql = "INSERT INTO usuarios VALUES('" + nombre + "','" + password + "','" + recuperacion +"')";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int filas = command.ExecuteNonQuery();

            if (filas == 1)
                return 0;
            else
                return - 2;
        }

        //Metodo boolean para cambiar contraseña, parametros: nombre, palabra de recuperacion y  nueva contraseña
        public bool CambiarPassword(string nombre, string recuperacion, string nuevaPassword)
        {
            string sql = "UPDATE usuarios SET password = '" + nuevaPassword + "' WHERE nombre = '" + nombre + "' AND recuperacion = '" + recuperacion + "'";
            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int filas = command.ExecuteNonQuery();
            return filas == 1;
        }
    }
}

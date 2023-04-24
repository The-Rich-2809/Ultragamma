using System.Data;
using System.Data.SqlClient;
using Ultragamma.Models;

namespace Ultragamma.Models
{
    public static class RegistrosModel
    {
        public static DataTable TablaUsuario = new DataTable();
        public static string _Correo { get; set; } = String.Empty;
        public static string _Contrasena { get; set; } = String.Empty;
        public static string _Nombre { get; set; } = String.Empty;
        public static string Mensaje { get; set; } = "";

        public static bool NuevoUsuario()
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                SqlCommand cmdSelect;
                int resultado = 0;
                string SentenciaSQL = @"Insert Into Usuarios Values (LOWER(@Correo),@Contrasena,@Nombre,2)";
                cmdSelect = new SqlCommand(SentenciaSQL, conexion);

                cmdSelect.Parameters.AddWithValue("@Correo", _Correo);
                cmdSelect.Parameters.AddWithValue("@Contrasena", _Contrasena);
                cmdSelect.Parameters.AddWithValue("@Nombre", _Nombre);

                try
                {
                    conexion.Open();
                    resultado = cmdSelect.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        Mensaje = "Usuario registrado correctamente";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message;
                }
            }
            return false;
        }

        public static bool IniciarSesion()
        {
            DataTable tablaUsuarios = new DataTable();
            using (SqlConnection conexion = Conexion.Conectar())
            {
                SqlCommand cmdSelect;
                SqlDataAdapter adapter = new SqlDataAdapter();

                string sentencia = @"Select * from Usuarios where Correo = @Correo and Contrasena = @Con;";
                try
                {
                    cmdSelect = new SqlCommand(sentencia, conexion);
                    cmdSelect.Parameters.AddWithValue("@Correo", _Correo);
                    cmdSelect.Parameters.AddWithValue("@Con", _Contrasena);
                    adapter.SelectCommand = cmdSelect;
                    conexion.Open();
                    adapter.Fill(tablaUsuarios);

                    if (tablaUsuarios.Rows.Count > 0)
                    {
                        TablaUsuario = tablaUsuarios;
                        return true;
                    }
                    else
                    {
                        Mensaje = "Usario y/o contraseña incorrectos";
                    }
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message;
                }
            }
            return false;
        }
        public static string[] Header()
        {
            string[] header = new string[2];
            if (TablaUsuario.Rows.Count > 0)
            {
                header[0] = Convert.ToString(TablaUsuario.Rows[0]["Nivel"]);
                header[1] = Convert.ToString(TablaUsuario.Rows[0]["Nombre"]);
            }
            return header;

        }
        public static void CerrarSesion()
        {
            TablaUsuario = new DataTable();
        }
    }
}

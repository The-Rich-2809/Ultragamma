using System.Data;
using System.Data.SqlClient;

namespace Ultragamma.Models
{
    public static class AlmacenModel
    {
        public static string Mensaje { get; set; } = "";
        public static DataTable ProductosHombres()
        {
            DataTable tablaProductos = new DataTable();

            using (SqlConnection conexion = Conexion.Conectar())
            {
                SqlCommand cmdSelect;
                SqlDataAdapter adapter = new SqlDataAdapter();

                string sentencia = "Select * from Productos";
                try
                {
                    cmdSelect = new SqlCommand(sentencia, conexion);
                    adapter.SelectCommand = cmdSelect;
                    conexion.Open();
                    adapter.Fill(tablaProductos);
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message;
                }
                return tablaProductos;
            }
        }
    }
}

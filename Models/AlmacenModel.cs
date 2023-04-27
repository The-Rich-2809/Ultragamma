using System.Data;
using System.Data.SqlClient;

namespace Ultragamma.Models
{
    public static class AlmacenModel
    {
        public static string Mensaje { get; set; } = "";
        public static string _Producto { get; set; } = String.Empty;
        public static string _Precio { get; set; } = String.Empty;
        public static string _Categoria { get; set; } = String.Empty;
        public static string _Cantidad { get; set; } = String.Empty;

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

        public static bool NuevoProducto()
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                SqlCommand cmdSelect;
                int resultado = 0;
                string SentenciaSQL = @"Insert Into Productos Values (3,@Producto,@Precio,@Categoria,@Cantidad)";
                cmdSelect = new SqlCommand(SentenciaSQL, conexion);

                cmdSelect.Parameters.AddWithValue("@Producto",_Producto );
                cmdSelect.Parameters.AddWithValue("@Precio", _Precio);
                cmdSelect.Parameters.AddWithValue("@Categoria", _Categoria);
                cmdSelect.Parameters.AddWithValue("@Cantidad", _Cantidad);

                try
                {
                    conexion.Open();
                    resultado = cmdSelect.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        Mensaje = "Producto registrado correctamente";
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
    }
}

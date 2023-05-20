namespace Ultragamma.Models
{
    public class ProductosModel
    {
        public readonly ApplicationDbContex _contexto;
        public ProductosModel(ApplicationDbContex contexto)
        {
            _contexto = contexto;
        }

        public void NuevoProducto(Producto producto)
        {
            _contexto.Producto.Add(producto);
            _contexto.SaveChanges();
        }
        public void EditarProducto(Producto producto)
        {
            _contexto.Producto.Update(producto);
            _contexto.SaveChanges();
        }
        public void EliminarProducto(Producto producto)
        {

        }
    }
}

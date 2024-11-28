
namespace AWF.Repository.Entities
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public Venta? RefVenta { get; set; }
        public Producto? RefProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
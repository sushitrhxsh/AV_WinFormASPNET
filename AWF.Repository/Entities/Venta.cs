
namespace AWF.Repository.Entities
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public string? NumeroVenta { get; set; }
        public Usuario? UsuarioRegistro { get; set; }
        public string? NombreCliente { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PagoCon { get; set; }
        public decimal Cambio { get; set; }
        public string? FechaRegistro { get; set; }
        public int Activo { get; set; }
        public List<DetalleVenta>? RefDetalleVenta { get; set; }
    }
}
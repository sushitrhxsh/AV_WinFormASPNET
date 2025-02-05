
using System.ComponentModel;

namespace AWF.Presentation.ViewModels
{
    public class ReporteVentaVM
    {
        [DisplayName("Numero Venta")]
        public string? NumeroVenta { get; set; }
        [DisplayName("Nombre Usuario")]
        public string? NombreUsuario { get; set; }
        [DisplayName("Fecha Registro")]
        public string? FechaRegistro { get; set; }
        public string? Producto { get; set; }
        [DisplayName("Precio Compra")]
        public decimal PrecioCompra { get; set; }
        [DisplayName("Precio Venta")]
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        [DisplayName("Precio Total")]
        public decimal PrecioTotal { get; set; }
    }
}
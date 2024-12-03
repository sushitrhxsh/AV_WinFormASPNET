using System.ComponentModel;

namespace AWF.Presentation.ViewModels
{
    public class DetalleVentaVM
    {
        public int IdProducto { get; set; }
        public string? Producto { get; set; }
        public decimal Precio { get; set; }
        public int CantidadValor { get; set; }
        [DisplayName("Cantidad")]
        public string? CantidadTexto { get; set; }
        public decimal Total { get; set; }
    }
}

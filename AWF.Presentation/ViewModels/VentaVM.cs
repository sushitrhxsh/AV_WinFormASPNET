
namespace AWF.Presentation.ViewModels
{
    public class VentaVM
    {
        [DisplayName("Fecha Registro")]
        public string FechaRegistro { get; set; }
        public string NumeroVenta { get; set; }
        public string Usuario { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
    }
}
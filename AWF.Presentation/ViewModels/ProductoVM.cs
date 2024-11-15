using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AWF.Presentation.ViewModels
{
    public class ProductoVM
    {
        public int IdProducto { get; set; }
        public string? Codigo { get; set; }        
        public string? Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public string? Categoria { get; set; }
        [DisplayName("Precio Compra")]
        public string? PrecioCompra { get; set; }
        [DisplayName("Precio Venta")]
        public string? PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public int Activo { get; set; }
        public string? Habilitado { get; set; }
    }
}
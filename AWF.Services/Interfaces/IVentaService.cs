using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface IVentaService
    {
        Task<string> Registrar(string ventaXml);
        Task<Venta> Obtener(string numeroVenta);  
        Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta); 
    }
}
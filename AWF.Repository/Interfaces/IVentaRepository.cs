using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface IVentaRepository
    {
        Task<string> Registrar(string ventaXml);
        Task<Venta> Obtener(string numeroVenta);  
        Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta); 
    }
}
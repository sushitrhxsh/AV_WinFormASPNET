using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Services.Implementation
{
    public class VentaService : IVentaService
    {

        private readonly IVentaRepository _ventaRepository;
        public VentaService(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<string> Registrar(string ventaXml)
        {
            var resultado = await _ventaRepository.Registrar(ventaXml);
            return resultado;
        }

        public async Task<Venta> Obtener(string numeroVenta)
        {
            var resultado = await _ventaRepository.Obtener(numeroVenta);
            return resultado;
        }

        public async Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta)
        {
            var resultado = await _ventaRepository.ObtenerDetalle(numeroVenta);
            return resultado;
        }

        public async Task<List<Venta>> Lista(string fechaInicio, string fechaFin, string buscar)
        {
            var resultado = await _ventaRepository.Lista(fechaInicio, fechaFin, buscar);
            return resultado;
        }

        public async Task<List<DetalleVenta>> Reporte(string fechaInicio, string fechaFin)
        {
            var resultado = await _ventaRepository.Reporte(fechaInicio, fechaFin);
            return resultado;
        }
        
    }
}
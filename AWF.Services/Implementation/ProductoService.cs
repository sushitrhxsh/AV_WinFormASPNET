using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Services.Implementation
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<Producto>> Lista(string buscar = "")
        {
            var resultado = await _productoRepository.Lista(buscar);
            return resultado;
        }

        public async Task<string> Crear(Producto modelo)
        {
            var resultado = await _productoRepository.Crear(modelo);
            return resultado;
        }

        public async Task<string> Editar(Producto modelo)
        {
            var resultado = await _productoRepository.Editar(modelo);
            return resultado;
        }

        public async Task<Producto> Obtener(string codigo)
        {
            var resultado = await _productoRepository.Obtener(codigo);
            return resultado;
        }
        
    }
}
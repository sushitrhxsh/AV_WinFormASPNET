using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Services.Implementation
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _categoriaRepository ;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> Lista(string buscar = "")
        {
            var resultado = await _categoriaRepository.Lista(buscar);
            return resultado;
        }

        public async Task<string> Crear(Categoria modelo)
        {
            var resultado = await _categoriaRepository.Crear(modelo);
            return resultado;
        }

        public async Task<string> Editar(Categoria modelo)
        {
            var resultado = await _categoriaRepository.Editar(modelo);
            return resultado;
        }
  
    }
}
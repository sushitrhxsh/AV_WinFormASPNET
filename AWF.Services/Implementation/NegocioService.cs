using AWF.Repository.Entities;
using AWF.Repository.Interfaces;

namespace AWF.Services.Implementation
{
    public class NegocioService : INegocioRepository
    {

        private readonly INegocioRepository _negocioRepository;
        public NegocioService(INegocioRepository negocioRepository)
        {
            _negocioRepository = negocioRepository;
        }

        public async Task<Negocio> Obtener()
        {
            var resultado = await _negocioRepository.Obtener();
            return resultado;
        }

        public async Task Editar(Negocio modelo)
        {
            var resultado = _negocioRepository.Editar(modelo);
            await resultado;
        }

    }
}
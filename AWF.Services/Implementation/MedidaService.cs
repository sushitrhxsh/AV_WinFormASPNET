using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Services.Implementation
{
    public class MedidaService : IMedidaService
    {
        
        private readonly IMedidaRepository _medidaRepository;
        public MedidaService(IMedidaRepository medidaRepository)
        {
            _medidaRepository = medidaRepository;
        }

        public async Task<List<Medida>> Lista()
        {
            var resultado = await _medidaRepository.Lista();
            return resultado;
        }

    }
}
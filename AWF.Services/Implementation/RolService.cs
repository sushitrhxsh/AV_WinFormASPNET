using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Services.Implementation
{
    public class RolService : IRolService
    {

        private readonly IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<List<Rol>> Lista()
        {
            var resultado = await _rolRepository.Lista();
            return resultado;
        }

    }
}
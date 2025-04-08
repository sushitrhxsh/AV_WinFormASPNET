using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Services.Implementation
{
    public class MenuRolService:IMenuRolService
    {
        
        private readonly IMenuRolRepository _menuRolRepository;
        public MenuRolService(IMenuRolRepository menuRolRepository)
        {
            _menuRolRepository = menuRolRepository;
        }

        public async Task<List<MenuRol>> Lista(int idRol)
        {
            var resultado = await _menuRolRepository.Lista(idRol);
            return resultado;
        }

    }
}
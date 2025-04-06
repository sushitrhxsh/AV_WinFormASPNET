
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;

namespace AWF.Services.Implementation
{
    public class MenuRolService
    {
        
        private readonly IMenuRolRepository _menuRolRepository;
        public MenuRolService(IMenuRolRepository menuRolRepository)
        {
            _menuRolRepository = menuRolRepository;
        }

        public async Task<List<MenuRol>> Lista(int idMenu, int idRol)
        {
            var resultado = await _menuRolRepository.Lista(idMenu, idRol);
            return resultado;
        }

    }
}
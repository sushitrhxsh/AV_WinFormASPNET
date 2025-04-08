using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface IMenuRolService
    {
        Task<List<MenuRol>> Lista(int idRol);
    }
}
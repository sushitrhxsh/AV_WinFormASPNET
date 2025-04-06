using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface IMenuRolRepository
    {
        Task<List<MenuRol>> Lista(int idMenu, int idRol);
    }
}
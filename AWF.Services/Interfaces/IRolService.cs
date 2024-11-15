using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface IRolService
    {
        Task<List<Rol>> Lista();
    }
}
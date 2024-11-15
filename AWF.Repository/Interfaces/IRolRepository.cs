using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> Lista();
    }
}
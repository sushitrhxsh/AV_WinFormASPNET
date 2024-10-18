using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface IMedidaRepository
    {
        Task<List<Medida>> Lista();
    }
}
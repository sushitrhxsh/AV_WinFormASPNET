using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface IMedidaService
    {
        Task<List<Medida>> Lista();
    }
}
using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface INegocioRepository
    {
        Task<Negocio> Obtener();
        Task Editar(Negocio modelo);
    }
}
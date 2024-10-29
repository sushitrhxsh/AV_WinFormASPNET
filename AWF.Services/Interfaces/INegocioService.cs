using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface INegocioService
    {
        Task <Negocio> Obtener();
        Task Editar(Negocio modelo);
    }
}
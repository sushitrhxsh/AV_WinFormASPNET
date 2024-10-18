using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> Lista(string buscar = "");
        Task<string> Crear(Categoria modelo);
        Task<string> Editar(Categoria modelo);
    }
}
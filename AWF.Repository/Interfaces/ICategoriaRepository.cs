using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> Lista(string buscar = "");
        Task<string> Crear(Categoria modelo);
        Task<string> Editar(Categoria modelo);
    }
}
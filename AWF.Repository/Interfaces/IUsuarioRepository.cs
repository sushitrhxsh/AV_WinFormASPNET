using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Lista(string buscar = "");
        Task<string> Crear(Usuario modelo);
        Task<string> Editar(Usuario modelo);
    }
}
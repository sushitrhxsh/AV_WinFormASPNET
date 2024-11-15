using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> Lista(string buscar = "");
        Task<string> Crear(Usuario modelo);
        Task<string> Editar(Usuario modelo);
    }
}
using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> Lista(string buscar = "");
        Task<string> Crear(Usuario modelo);
        Task<string> Editar(Usuario modelo);
        Task<Usuario> Login(string usuario, string clave);
        Task<int> VerificarCorreo(string correo);
        Task ActualizarClave(int idUsuario, string nuevaClave, int resetear);

    }
}
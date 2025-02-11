using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> Lista(string buscar = "")
        {
            var resultado = await _usuarioRepository.Lista(buscar);
            return resultado;
        }

        public async Task<string> Crear(Usuario modelo)
        {
            var resultado = await _usuarioRepository.Crear(modelo);
            return resultado;
        }

        public async Task<string> Editar(Usuario modelo)
        {
            var resultado = await _usuarioRepository.Editar(modelo);
            return resultado;
        }

        public async Task<Usuario> Login(string usuario, string clave)
        {
            var resultado = await _usuarioRepository.Login(usuario, clave);
            return resultado;
        }

        public Task<int> VerificarCorreo(string correo)
        {
            var resultado = _usuarioRepository.VerificarCorreo(correo);
            return resultado;
        }

        public Task ActualizarClave(int idUsuario, string nuevaClave, int resetear)
        {
            var resultado = _usuarioRepository.ActualizarClave(idUsuario, nuevaClave, resetear);
            return resultado;
        }

    }
}
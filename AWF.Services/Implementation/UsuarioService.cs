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
        
    }
}

namespace AWF.Repository.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public Rol? RefRol { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Clave { get; set; }
        public int ResetearClave { get; set; }
        public int Activo { get; set; }
    }
}
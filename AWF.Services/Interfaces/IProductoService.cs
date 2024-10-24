using AWF.Repository.Entities;

namespace AWF.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> Lista(string buscar = "");
        Task<string> Crear(Producto modelo);
        Task<string> Editar(Producto modelo);
    }
}
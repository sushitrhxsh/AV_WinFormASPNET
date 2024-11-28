using AWF.Repository.Entities;

namespace AWF.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> Lista(string buscar = "");
        Task<string> Crear(Producto modelo);
        Task<string> Editar(Producto modelo);
        Task<Producto> Obtener(string codigo);
    }
}
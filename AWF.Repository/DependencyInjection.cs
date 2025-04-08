using Microsoft.Extensions.DependencyInjection;
using AWF.Repository.Implementation;
using AWF.Repository.Interfaces;
using AWF.Repository.DB;

namespace AWF.Repository
{
    public static class DependencyInjection
    {
        public static void InyeccionDependenciasRepository(this IServiceCollection services)
        {
            services.AddSingleton<Conexion>();
            services.AddTransient<IMedidaRepository,    MedidaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProductoRepository,  ProductoRepository>();
            services.AddTransient<INegocioRepository,   NegocioRepository>();
            services.AddTransient<IRolRepository,       RolRepository>();
            services.AddTransient<IUsuarioRepository,   UsuarioRepository>();
            services.AddTransient<IVentaRepository,     VentaRepository>();
            services.AddTransient<IMenuRolRepository,   MenuRolRepository>();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using AWF.Services.Interfaces;
using AWF.Services.Implementation;

namespace AWF.Services
{
    public static class DependencyInjection
    {
        public static void InyeccionDependenciasService(this IServiceCollection services)
        {
            services.AddTransient<IMedidaService,     MedidaService>();
            services.AddTransient<ICategoriaService,  CategoriaService>();
            services.AddTransient<IProductoService,   ProductoService>();
            services.AddTransient<INegocioService,    NegocioService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IRolService,        RolService>();
            services.AddTransient<IUsuarioService,    UsuarioService>();
            services.AddTransient<ICorreoService,     CorreoService>();
            services.AddTransient<IVentaService,      VentaService>();
            services.AddTransient<IMenuRolService,    MenuRolService>();
        }
    }
}
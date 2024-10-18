using Microsoft.Extensions.DependencyInjection;
using AWF.Services.Interfaces;
using AWF.Services.Implementation;

namespace AWF.Services
{
    public static class DependencyInjection
    {
        public static void InyeccionDependenciasService(this IServiceCollection services)
        {
            services.AddTransient<IMedidaService,MedidaService>();
            services.AddTransient<ICategoriaService,CategoriaService>();
        }
    }
}
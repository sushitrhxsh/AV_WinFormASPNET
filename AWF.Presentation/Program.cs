using AWF.Presentation.Formularios;
using AWF.Repository;
using AWF.Repository.Implementation;
using AWF.Repository.Interfaces;
using AWF.Services;
using AWF.Services.Implementation;
using AWF.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AWF.Presentation;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var host = CreateHostBuilder().Build();
        var formService = host.Services.GetRequiredService<frmLogin>();

        Application.Run(formService);
    }

    static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration((context, config) => 
        {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((context,services) => 
        {
            //Repositories
            services.InyeccionDependenciasRepository();
            //Services
            services.InyeccionDependenciasService();

            services.AddTransient<frmCategoria>();
            services.AddTransient<frmProducto>();
            services.AddTransient<frmNegocio>();
            services.AddTransient<frmUsuario>();
            services.AddTransient<frmVenta>();
            services.AddTransient<frmBuscarProducto>();
            services.AddTransient<frmHistorial>();
            services.AddTransient<frmDetalleVenta>();
            services.AddTransient<frmReporte>();
            services.AddTransient<frmLogin>();
            services.AddTransient<frmActualizarClave>();
        });
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AWF.Presentation.Utilidades;
using AWF.Presentation.ViewModels;
using AWF.Repository.Interfaces;
using AWF.Services.Interfaces;

namespace AWF.Presentation.Formularios
{
    public partial class frmHistorial : Form
    {

        private readonly IVentaService _ventaService;
        private readonly IServiceProvider _serviceProvider;
        public frmHistorial(IVentaService ventaService, IServiceProvider serviceProvider)
        {
            _ventaService = ventaService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private async Task MostrarVenta()
        {
            var listaVenta = await _ventaService.Lista(
                dtpFechaInicio.Value.ToString("dd/MM/yyyy"), dtpFechaFin.Value.ToString("dd/MM/yyyy"), txbBuscar.Text.Trim());

            var listaVM = listaVenta.Select(item => new VentaVM {
                FechaRegistro = item.FechaRegistro!,
                NumeroVenta   = item.NumeroVenta!,
                Usuario       = item.UsuarioRegistro!.NombreUsuario!,
                Cliente       = item.NombreCliente!,
                Total         = item.PrecioTotal
            }).ToList();

            dgvVenta.DataSource = listaVM;
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            dgvVenta.ImplementarConfiguracion("Ver");
            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarVenta();
        }

    }
}

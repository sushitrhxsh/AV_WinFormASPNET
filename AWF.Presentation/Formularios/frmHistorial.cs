using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            await _ventaService.Lista(
                dtpFechaInicio.Value.ToString("dd/MM/yyyy"), dtpFechaFin.Value.ToString("dd/MM/yyyy"), txbBuscar.Text.Trim());
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {

        }
    }
}

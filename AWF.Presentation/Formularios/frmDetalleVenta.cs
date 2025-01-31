using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AWF.Presentation.Utilidades;
using AWF.Presentation.ViewModels;
using AWF.Repository.Entities;
using AWF.Services.Interfaces;

namespace AWF.Presentation.Formularios
{
    public partial class frmDetalleVenta : Form
    {

        private readonly IVentaService _ventaService;
        private readonly INegocioService _negocioService;
        public string _numeroVenta { get; set; } = null!;
        [Obsolete]
        public frmDetalleVenta(INegocioService negocioService, IVentaService ventaService)
        {
            _ventaService = ventaService;
            _negocioService = negocioService;

            InitializeComponent();
        }

        private async void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            dgvDetalle.ImplementarConfiguracion();
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var detalleVenta = await _ventaService.ObtenerDetalle(_numeroVenta);

            var listaVM = detalleVenta.Select(x => new DetalleVentaVM{
                Producto      = x.RefProducto?.Descripcion,
                CantidadTexto = string.Concat(x.Cantidad, " ", x.RefProducto?.RefCategoria?.RefMedida?.Equivalente),
                Total         = x.PrecioTotal 
            }).ToList();

            lblNumeroVenta.Text = _numeroVenta;

            dgvDetalle.DataSource = listaVM;
            dgvDetalle.Columns["IdProducto"].Visible = false;
            dgvDetalle.Columns["CantidadValor"].Visible = false;
        }

        [Obsolete]
        private async void btnVerPDF_Click(object sender, EventArgs e)
        {
            var oNegocio           = await _negocioService.Obtener();
            var oVenta             = await _ventaService.Obtener(_numeroVenta);
            var oDetalleVenta      = await _ventaService.ObtenerDetalle(_numeroVenta);
            oVenta.RefDetalleVenta = oDetalleVenta;

            MemoryStream imagenLogo;
            using(var httpClient = new HttpClient()) {
                var imgBytes = await httpClient.GetByteArrayAsync(oNegocio.UrlLogo);
                imagenLogo   = new MemoryStream(imgBytes);
            }

            var arrayPdf = Util.GeneratePDFVenta(oNegocio,oVenta,imagenLogo);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter       = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title        = "Guardar PDF";
                saveFileDialog.DefaultExt   = "pdf";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName     = $"Venta_{_numeroVenta}.pdf";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                    await File.WriteAllBytesAsync(saveFileDialog.FileName,arrayPdf);
                    Process.Start(new ProcessStartInfo {
                        FileName        = saveFileDialog.FileName,
                        UseShellExecute = true
                    });
            };
        }

    }
}

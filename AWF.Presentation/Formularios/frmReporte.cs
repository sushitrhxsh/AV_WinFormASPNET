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
using AWF.Repository.Entities;
using AWF.Services.Interfaces;
using ClosedXML.Excel;

namespace AWF.Presentation.Formularios
{
    public partial class frmReporte : Form
    {
        
        private readonly IVentaService _ventaService;
        public frmReporte(IVentaService ventaService)
        {
            _ventaService = ventaService;
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            dgvReporte.ImplementarConfiguracion();
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var listaReporte =  await _ventaService.Reporte(
                dtpFechaInicio.Value.ToString("dd/MM/yyyy"), dtpFechaFin.Value.ToString("dd/MM/yyyy")
            );

            var listaVM = listaReporte.Select(item => new ReporteVentaVM {
                NumeroVenta   = item.RefVenta!.NumeroVenta,
                NombreUsuario = item.RefVenta.UsuarioRegistro!.NombreUsuario,
                FechaRegistro = item.RefVenta.FechaRegistro,
                Producto      = item.RefProducto!.Descripcion,
                PrecioCompra  = item.RefProducto!.PrecioCompra,
                PrecioVenta   = item.PrecioVenta,
                Cantidad      = item.Cantidad,
                PrecioTotal   = item.PrecioTotal
            }).ToList();

            dgvReporte.DataSource = listaVM;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if(dgvReporte.Rows.Count == 0) {
                MessageBox.Show("No hay datos para exportar", "Exportar a Excel");
                return;
            }

            DataTable tabla = new DataTable();
            List<ReporteVentaVM> detalle = (List<ReporteVentaVM>)dgvReporte.DataSource;

            foreach(DataGridViewColumn columna in dgvReporte.Columns) 
                tabla.Columns.Add(columna.HeaderText, typeof(string));

            foreach(var item in detalle) {
                tabla.Rows.Add(
                    item.NumeroVenta,
                    item.NombreUsuario,
                    item.FechaRegistro,
                    item.Producto,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Cantidad,
                    item.PrecioTotal
                );
            }

            using (SaveFileDialog saveFile = new SaveFileDialog()) {
                saveFile.FileName = $"ReporteVenta {DateTime.Now.ToString("dd-MM-yyyy")}";
                saveFile.Filter   = "Excel files (*.xlsx)|*.xlsx";
                saveFile.Title    = "Exportar a Excel";

                if(saveFile.ShowDialog() == DialogResult.OK) {
                    try 
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(tabla, "Reporte");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }

    }
}

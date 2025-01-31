using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using AWF.Presentation.Utilidades;
using AWF.Presentation.ViewModels;
using AWF.Repository.Entities;
using AWF.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Numerics;
using System.Xml.Linq;
using System.Diagnostics;

namespace AWF.Presentation.Formularios
{
    public partial class frmVenta : Form
    {

        private readonly IProductoService _productoService;
        private readonly IVentaService _ventaService;
        private readonly INegocioService _negocioService;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<DetalleVentaVM> _detalleVenta = new BindingList<DetalleVentaVM>();
        [Obsolete]
        public frmVenta(IProductoService productoService, IVentaService ventaService, INegocioService negocioService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            
            _productoService = productoService;
            _ventaService = ventaService;
            _negocioService = negocioService;
            _serviceProvider = serviceProvider;
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            dgvDetalleVenta.ImplementarConfiguracion("Eliminar");
            dgvDetalleVenta.DataSource                       = _detalleVenta;
            dgvDetalleVenta.Columns["IdProducto"].Visible    = false;
            dgvDetalleVenta.Columns["CantidadValor"].Visible = false;
            dgvDetalleVenta.Columns["Producto"].FillWeight   = 350;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txbPagoCon.ValidarNumero();
        }

        private async Task AgregarProducto(string codigoProducto)
        {
            var producto = await _productoService.Obtener(codigoProducto);
            
            if(producto.IdProducto == 0) {
                txbCodigoProducto.BackColor = Color.FromArgb(255,227,227);
                return;
            }

            txbCodigoProducto.BackColor = SystemColors.Window;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(producto.Descripcion);
            sb.AppendLine("Categoria: " + producto.RefCategoria!.Nombre);
            sb.AppendLine("Precio: " + producto.PrecioVenta.ToString("0.00"));
            sb.AppendLine();
            sb.AppendLine("Ingresa la cantidad( " + producto.RefCategoria.RefMedida!.Equivalente + " )");

            string cantidadString = Interaction.InputBox(sb.ToString(),"Producto", "1");
            int cantidad;

            if(string.IsNullOrEmpty(cantidadString))
                return;
            
            if(!int.TryParse(cantidadString,out cantidad)) {
                MessageBox.Show("El valor ingresado no es un numero");
                return;
            }
            
            if(cantidad > producto.Cantidad) {
                MessageBox.Show("La cantidad ingresada no puede exceder al stock");
                return;
            }

            var encontrado = _detalleVenta.FirstOrDefault(x => x.IdProducto == producto.IdProducto);
            
            if(encontrado == null) {
                decimal total = (cantidad * producto.PrecioVenta)/producto.RefCategoria.RefMedida.Valor;

                _detalleVenta.Add(new DetalleVentaVM {
                    IdProducto    = producto.IdProducto,
                    Producto      = producto.Descripcion,
                    Precio        = producto.PrecioVenta,
                    CantidadValor = cantidad,
                    CantidadTexto = string.Concat(cantidad,"",producto.RefCategoria.RefMedida.Equivalente),
                    Total         = Convert.ToDecimal(total.ToString("0.00"))
                });

            }  else { 
                int index = _detalleVenta.IndexOf(encontrado);
                int cantidadTotal = encontrado.CantidadValor + cantidad;
                decimal total = (cantidadTotal * producto.PrecioVenta)/producto.RefCategoria.RefMedida.Valor;

                encontrado.CantidadValor = cantidadTotal;
                encontrado.CantidadTexto = string.Concat(cantidadTotal + "" + producto.RefCategoria.RefMedida.Equivalente);
                encontrado.Total         = Convert.ToDecimal(total.ToString("0.00"));
                _detalleVenta[index] = encontrado;
            }

            decimal Total          = _detalleVenta.Sum(x => x.Total);
            label9.Text            = Total.ToString("0.00");
            txbCodigoProducto.Text = "";
        }

        private async void txbCodigoProducto_KeyDown(object sender, KeyEventArgs e) 
        {
            if(e.KeyData == Keys.Enter)
                await AgregarProducto(txbCodigoProducto.Text.Trim());
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var _formBuscarProducto = _serviceProvider.GetRequiredService<frmBuscarProducto>();
            var result = _formBuscarProducto.ShowDialog();

            if(result == DialogResult.OK) {
                var productoSeleccionado = _formBuscarProducto._productoSeleccionado;
                txbCodigoProducto.Text   = productoSeleccionado.Codigo;

                await AgregarProducto(productoSeleccionado.Codigo!);
            }
        }

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetalleVenta.Columns[e.ColumnIndex].Name == "ColumnaAccion") {
                var filaSeleccionada = (DetalleVentaVM) dgvDetalleVenta.CurrentRow.DataBoundItem;

                var index = _detalleVenta.IndexOf(filaSeleccionada);
                _detalleVenta.RemoveAt(index);
                
                decimal Total = _detalleVenta.Sum(x => x.Total);
                label9.Text   = Total.ToString("0.00");   
            }
        }

        [Obsolete]
        private async void btnGuardar_Click(object sender,EventArgs e)
        {
            if(_detalleVenta.Count == 0) {
                MessageBox.Show("No hay productos");
                return;
            }

            decimal tempTotal = _detalleVenta.Sum(x => x.Total);
            var precioTotal   = Convert.ToDecimal(tempTotal.ToString("0.00"));

            var pagoCon       = txbPagoCon.Text.Trim() == "" ? precioTotal : Convert.ToDecimal(txbPagoCon.Text.Trim());
            var cambio        = txbCambio.Text.Trim() == "" ? 0 : Convert.ToDecimal(txbCambio.Text.Trim());

            //TODO: Ingresar el id del usuario logueado
            XElement venta = new XElement("Venta",
                new XElement("IdUsuarioRegistro", 1),
                new XElement("NombreCliente", txbNombreCliente.Text.Trim()),
                new XElement("PrecioTotal",   precioTotal),
                new XElement("PagoCon",       pagoCon),
                new XElement("Cambio",        cambio)
            );

            XElement detalleventa = new XElement("DetalleVenta");
            foreach(var item in _detalleVenta) {
                detalleventa.Add(new XElement("Item",
                    new XElement("IdProducto",  item.IdProducto),
                    new XElement("Cantidad",    item.CantidadValor),
                    new XElement("PrecioVenta", item.Precio),
                    new XElement("PrecioTotal", item.Total)
                ));
            }

            venta.Add(detalleventa);

            var numeroVenta = await _ventaService.Registrar(venta.ToString());
            if(numeroVenta == "") {
                MessageBox.Show("No se pudo registrar la venta");
                return;
            }

            txbCodigoProducto.Text  = "";
            txbNombreCliente.Text   = "";
            _detalleVenta.Clear();
            label9.Text             = "0";
            txbPagoCon.Text         = "";
            txbCambio.Text          = "";
            txbCodigoProducto.Select();

            DialogResult result = MessageBox.Show(
                $"Numero de venta:{numeroVenta}\n¿Desea guardar y visualizar el documento?",
                "Venta registrada correctamente",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information
            );

            if(result == DialogResult.Yes) {
                var oNegocio           = await _negocioService.Obtener();
                var oVenta             = await _ventaService.Obtener(numeroVenta);
                var oDetalleVenta      = await _ventaService.ObtenerDetalle(numeroVenta);
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
                    saveFileDialog.FileName     = $"Venta_{numeroVenta}.pdf";

                    if(saveFileDialog.ShowDialog() == DialogResult.OK)
                        await File.WriteAllBytesAsync(saveFileDialog.FileName,arrayPdf);
                        Process.Start(new ProcessStartInfo {
                            FileName        = saveFileDialog.FileName,
                            UseShellExecute = true
                        });
                };
            }
        }

        private void txbPagoCon_KeyDown(Object sender, KeyEventArgs e)
        {
            if(e.KeyData != Keys.Enter)
                return;
            
            decimal pagoCon;
            decimal total = _detalleVenta.Sum(x => x.Total);

            if(txbPagoCon.Text.Trim() != "")
                if(decimal.TryParse(txbPagoCon.Text.Trim(),out pagoCon)){
                    if(pagoCon < total) {
                        txbCambio.Text = "0.00";
                        
                    } else {
                        decimal cambio = pagoCon - total;
                        txbCambio.Text = cambio.ToString("0.00");
                    }

                } else {
                    MessageBox.Show("El valor ingresado no es valido");
                }
            
        }

    }
}

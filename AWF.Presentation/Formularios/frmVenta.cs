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

namespace AWF.Presentation.Formularios
{
    public partial class frmVenta : Form
    {

        private readonly IProductoService _productoService;
        private readonly IVentaService _ventaService;
        private readonly INegocioService _negocioService;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<DetalleVentaVM> _detalleVenta = new BindingList<DetalleVentaVM>();
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

                encontrado.CantidadValor += cantidadTotal;
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

    }
}

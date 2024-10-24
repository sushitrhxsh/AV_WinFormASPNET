using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AWF.Presentation.ViewModels;
using AWF.Repository.Entities;
using AWF.Services.Interfaces;
using AWF.Presentation.Utilidades;
using AWF.Presentation.Utilidades.Objetos;

namespace AWF.Presentation.Formularios
{
    public partial class frmCategoria : Form
    {

        private readonly IMedidaService _medidaService;
        private readonly ICategoriaService _categoriaService;
        public frmCategoria(ICategoriaService categoriaService, IMedidaService medidaService)
        {
            InitializeComponent();
            _categoriaService = categoriaService;
            _medidaService = medidaService;
        }

        public void MostrarTab(string tabName)
        {
            var TabsMenu = new TabPage[] { tabLista, tabNuevo, tabEditar };

            foreach (var tab in TabsMenu)
            {
                if (tab.Name != tabName)
                    tab.Parent = null;
                else
                    tab.Parent = tabControlMain;
            }
        }

        private async Task MostrarCategorias(string buscar = "")
        {
            var listaCategorias = await _categoriaService.Lista(buscar);

            var listaVM = listaCategorias.Select(item => new CategoriaVM
            {
                IdCategoria = item.IdCategoria,
                Nombre      = item.Nombre,
                IdMedida    = item.RefMedida.IdMedida,
                Medida      = item.RefMedida.Nombre,
                Activo      = item.Activo,
                Habilitado  = item.Activo == 1 ? "Si" : "No"
            }).ToList();

            dgvCategorias.AutoGenerateColumns = true;
            dgvCategorias.DataSource          = listaVM;

            dgvCategorias.Columns["IdCategoria"].Visible = false;
            dgvCategorias.Columns["IdMedida"].Visible    = false;
            dgvCategorias.Columns["Activo"].Visible      = false;
        }

        private async void frmCategoria_Load(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
            dgvCategorias.ImplementarConfiguracion("Editar");
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            await MostrarCategorias();

            OpcionCombo[] itemsHabilitado = new OpcionCombo[] {
                new OpcionCombo { Texto = "Si", Valor = 1 },
                new OpcionCombo { Texto = "No", Valor = 0 }
            };

            var listaMedida = await _medidaService.Lista();
            var items = listaMedida.Select(item => new OpcionCombo { Texto = item.Nombre, Valor = item.Valor, }).ToArray();

            cbbMedidaNuevo.InsertarItems(items);
            cbbMedidaEditar.InsertarItems(items);

            cbbHabilitado.InsertarItems(itemsHabilitado);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarCategorias(txbBuscar.Text);
        }

        private void btnNuevoLista_Click(object sender, EventArgs e)
        {
            txbNombreNuevo.Text = "";
            cbbMedidaNuevo.SelectedIndex = 0;
            txbNombreNuevo.Select();
            
            MostrarTab(tabNuevo.Name);
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
        }

        private async void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (txbNombreNuevo.Text.Trim() == "") {
                MessageBox.Show("Debe ingresar el nombre");
                return;
            }

            var item = (OpcionCombo)cbbMedidaNuevo.SelectedItem!;
            var objeto = new Categoria {
                Nombre    = txbNombreNuevo.Text.Trim(),
                RefMedida = new Medida { IdMedida = item.Valor }
            };

            var response = await _categoriaService.Crear(objeto);
            if (response != "") {
                MessageBox.Show(response);
            } else {
                await MostrarCategorias();
                MostrarTab(tabLista.Name);
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var categoriaSeleccionada = (CategoriaVM)dgvCategorias.CurrentRow.DataBoundItem;

                txbNombreEditar.Text = categoriaSeleccionada.Nombre.ToString();
                cbbMedidaEditar.EstablecerValor(categoriaSeleccionada.IdMedida);
                cbbHabilitado.EstablecerValor(categoriaSeleccionada.Activo);

                MostrarTab(tabEditar.Name);
                txbNombreEditar.Select();
            }
        }

        private void btnVolverEditar_Click(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
        }

        private async void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            if (txbNombreEditar.Text.Trim() == "") {
                MessageBox.Show("Debe ingresar el nombre");
                return;
            }

            var categoriaSeleccionada = (CategoriaVM)dgvCategorias.CurrentRow.DataBoundItem;
            var objeto = new Categoria {
                IdCategoria = categoriaSeleccionada.IdCategoria,
                Nombre      = txbNombreEditar.Text.Trim(),
                RefMedida   = new Medida { IdMedida = ((OpcionCombo)cbbMedidaEditar.SelectedItem!).Valor },
                Activo      = ((OpcionCombo)cbbHabilitado.SelectedItem!).Valor
            };

            var response = await _categoriaService.Editar(objeto);
            if (response != "") {
                MessageBox.Show(response);
            } else {
                await MostrarCategorias();
                MostrarTab(tabLista.Name);
            }
        }

    }
}

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
using AWF.Presentation.Utilidades.Objetos;
using AWF.Presentation.ViewModels;
using AWF.Repository.Entities;
using AWF.Services.Interfaces;

namespace AWF.Presentation.Formularios
{
    public partial class frmUsuario : Form
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IRolService _rolService;
        private readonly ICorreoService _correoService;
        public frmUsuario(IUsuarioService usuarioService,IRolService rolService,ICorreoService correoService)
        {
            InitializeComponent();
            _correoService = correoService;
            _usuarioService = usuarioService;
            _rolService = rolService;
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

        private async Task MostrarUsuarios(string buscar = "")
        {
            var listaUsuario = await _usuarioService.Lista(buscar);

            var listaVM = listaUsuario.Select(item => new UsuarioVM {
                IdUsuario       = item.IdUsuario,
                IdRol           = item.RefRol!.IdRol,
                Rol             = item.RefRol.Nombre,
                NombreCompleto  = item.NombreCompleto,
                Correo          = item.Correo,
                NombreUsuario   = item.NombreUsuario,
                Activo          = item.Activo,
                Habilitado      = item.Activo == 1 ? "Si" : "No"
            }).ToList();

            dgvUsuarios.DataSource = listaVM;

            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdRol"].Visible     = false;
            dgvUsuarios.Columns["Activo"].Visible    = false;
        }

        private async void frmUsuario_Load(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
            dgvUsuarios.ImplementarConfiguracion("Editar");
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            await MostrarUsuarios();

            OpcionCombo[] itemsHabilitado = new OpcionCombo[] {
                new OpcionCombo { Texto = "Si", Valor = 1 },
                new OpcionCombo { Texto = "No", Valor = 0 }
            };

            var listaRol = await _rolService.Lista();
            var items = listaRol.Select(item => new OpcionCombo { Texto = item.Nombre, Valor = item.IdRol, }).ToArray();

            cbbRolNuevo.InsertarItems(items);
            cbbRolNuevo.InsertarItems(items);

            cbbHabilitado.InsertarItems(itemsHabilitado);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarUsuarios(txbBuscar.Text);
        }

        private void btnNuevoLista_Click(object sender, EventArgs e)
        {
            txbNombreCompletoNuevo.Text = "";
            cbbRolNuevo.SelectedIndex   = 0;
            txbCorreoNuevo.Text         = "";
            txbNombreCompletoNuevo.Text = "";
            cbbRolNuevo.Select();
            
            MostrarTab(tabNuevo.Name);
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
        }

        private async void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (txbNombreCompletoNuevo.Text.Trim() == "") {
                MessageBox.Show("Debes ingresar el nombre completo");
                return;
            }

            if (txbCorreoNuevo.Text.Trim() == "") {
                MessageBox.Show("Debes ingresar el correo");
                return;
            }

            if (txbNombreUsuarioNuevo.Text.Trim() == "") {
                MessageBox.Show("Debes ingresar el nombre de usuario");
                return;
            }

            var claveGenerada = Util.GenerateCode();
            var claveSha256   = Util.ConvertToSha256(claveGenerada);

            var item   = (OpcionCombo)cbbRolNuevo.SelectedItem!;
            var objeto = new Usuario {
                NombreCompleto  = txbNombreCompletoNuevo.Text.Trim(),
                Correo          = txbCorreoNuevo.Text.Trim(),
                NombreUsuario   = txbNombreUsuarioNuevo.Text.Trim(),
                Clave           = claveSha256,
                RefRol          = new Rol { IdRol = item.Valor }
            };

            var response = await _usuarioService.Crear(objeto);
            var mensaje  = $"Bienvenido<br>Su contraseña temporal es:{claveGenerada}<br>";

            if (!string.IsNullOrEmpty(response)) 
                MessageBox.Show(response);
            else 
                await _correoService.Enviar(objeto.Correo,"Cuenta Creada",mensaje);

                await MostrarUsuarios();
                MostrarTab(tabLista.Name);
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "ColumnaAccion") {
                var usuarioSeleccionado = (UsuarioVM)dgvUsuarios.CurrentRow.DataBoundItem;

                txbNombreCompletoEditar.Text = usuarioSeleccionado.NombreCompleto!.ToString();
                txbNombreUsuarioEditar.Text  = usuarioSeleccionado.NombreUsuario!.ToString();
                txbCorreoEditar.Text         = usuarioSeleccionado.Correo!.ToString();

                cbbRolEditar.EstablecerValor(usuarioSeleccionado.IdRol);
                cbbHabilitado.EstablecerValor(usuarioSeleccionado.Activo);

                MostrarTab(tabEditar.Name);
                cbbRolEditar.Select();
            }
        }

        private void btnVolverEditar_Click(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
        }

        private async void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            if (txbNombreCompletoEditar.Text.Trim() == "") {
                MessageBox.Show("Debes ingresar el nombre completo");
                return;
            }

            if (txbCorreoEditar.Text.Trim() == "") {
                MessageBox.Show("Debes ingresar el correo");
                return;
            }

            if (txbNombreUsuarioEditar.Text.Trim() == "") {
                MessageBox.Show("Debes ingresar el nombre de usuario");
                return;
            }

            var usuarioSeleccionado = (UsuarioVM)dgvUsuarios.CurrentRow.DataBoundItem;

            var item   = (OpcionCombo)cbbRolEditar.SelectedItem!;
            var item2  = (OpcionCombo)cbbHabilitado.SelectedItem!;
            var objeto = new Usuario {
                IdUsuario       = usuarioSeleccionado.IdUsuario,
                NombreCompleto  = txbNombreCompletoEditar.Text.Trim(),
                Correo          = txbCorreoEditar.Text.Trim(),
                NombreUsuario   = txbNombreUsuarioEditar.Text.Trim(),
                RefRol          = new Rol { IdRol = item.Valor },
                Activo          = item2.Valor
            };

            var response = await _usuarioService.Editar(objeto);

            if (!string.IsNullOrEmpty(response)) 
                MessageBox.Show(response);
            else 
                await MostrarUsuarios();
                MostrarTab(tabLista.Name);
        }

    }
}

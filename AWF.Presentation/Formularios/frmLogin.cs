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
using AWF.Services.Implementation;
using AWF.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace AWF.Presentation.Formularios
{
    public partial class frmLogin : Form
    {

        private readonly IUsuarioService _usuarioService;
        private readonly ICorreoService _correoService;
        private readonly IServiceProvider _serviceProvider;

        public frmLogin(IUsuarioService usuarioService, ICorreoService correoService, IServiceProvider serviceProvider)
        {
            _usuarioService = usuarioService;
            _correoService = correoService;
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txbUsuario.Select();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txbUsuario.Text) || string.IsNullOrWhiteSpace(txbPassword.Text)) {
                MessageBox.Show("Por favor ingrese su usuario y contraseña.");
                return;
            }

            var hash = Util.ConvertToSha256(txbPassword.Text.Trim());
            var response = await _usuarioService.Login(txbUsuario.Text.Trim(), hash);

            if(response.IdUsuario == 0) {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            if(response.Activo == 0) {
                MessageBox.Show("El usuario esta deshabilitado.");
                return;
            }

            if(response.ResetearClave == 1) {
                var _formActualizarClave = _serviceProvider.GetRequiredService<frmActualizarClave>();

                _formActualizarClave._idUsuario = response.IdUsuario;
                var resultado = _formActualizarClave.ShowDialog();
                
                if(resultado == DialogResult.OK) {
                    txbPassword.Text = "";
                    txbPassword.Select();
                    MessageBox.Show("La contraseña ha sido actualizada correctamente, intente ingresar.");
                }

            } else {
                UsuarioSesion.IdUsuario     = response.IdUsuario;
                UsuarioSesion.NombreUsuario = response.NombreUsuario;
                UsuarioSesion.IdRol         = response.RefRol!.IdRol;
                UsuarioSesion.Rol           = response.RefRol.Nombre;
                
                var _formLayout = _serviceProvider.GetRequiredService<frmCategoria>();
                this.Hide();
                txbUsuario.Text  = "";
                txbPassword.Text = "";

                _formLayout.Show();

                _formLayout.FormClosed += (sender, e) => {
                    this.Show();
                    txbUsuario.Select();
                };
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void linkOlvidePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var correo    = Interaction.InputBox("Ingrese su correo de usuario","Olvide mi contraseña");
            var idUsuario = await _usuarioService.VerificarCorreo(correo);

            if(idUsuario == 0) {
                MessageBox.Show("Correo no encontrado.");
                return;
            }

            var claveGenerada = Util.GenerateCode();
            var claveSha256   = Util.ConvertToSha256(claveGenerada);

            await _usuarioService.ActualizarClave(idUsuario, claveSha256, 1);

            var msj = $"Contraseña Actualizada <br> Su contraseña temporal es: {claveGenerada} <br> Por favor cambie su contraseña temporal al ingresar.";
            
            await _correoService.Enviar(correo, "Contraseña Actulizada", msj);
            
            MessageBox.Show("Su contraseña ha sido restablecida, revise su correo.");
        }

    }
}

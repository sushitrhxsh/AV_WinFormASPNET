using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AWF.Repository.Entities;
using AWF.Services.Interfaces;
using AWF.Services.Recursos.Cloudinary;

namespace AWF.Presentation.Formularios
{
    public partial class frmNegocio : Form
    {

        private readonly INegocioService _negocioService;
        private readonly ICloudinaryService _cloudinaryService;
        OpenFileDialog _openFileDialog = new OpenFileDialog();
        Negocio _negocio = new Negocio();
        public frmNegocio(INegocioService negocioService, ICloudinaryService cloudinaryService)
        {
            InitializeComponent();
            _negocioService = negocioService;
            _cloudinaryService = cloudinaryService;
        }

        private async void frmNegocio_Load(object sender, EventArgs e)
        {
            _openFileDialog.Filter = "Escoger imagen(*.JPG;*.PNG)|*.jpg;*.png";
            pbLogo.SizeMode        = PictureBoxSizeMode.StretchImage;

            _negocio = await _negocioService.Obtener();

            txbRazonSocial.Text   = _negocio.RazonSocial;
            txbRfc.Text           = _negocio.RFC;
            txbDireccion.Text     = _negocio.Direccion;
            txbNumCelular.Text    = _negocio.NumCelular;
            txbCorreo.Text        = _negocio.Correo;
            txbSimboloMoneda.Text = _negocio.SimboloMoneda;

            if (_negocio.UrlLogo != "")
                pbLogo.ImageLocation = _negocio.UrlLogo;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK) {
                _openFileDialog.OpenFile();
                pbLogo.Image = Image.FromFile(_openFileDialog.FileName);

                txbRutaImagen.Text = _openFileDialog.FileName;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            CloudinaryResponse cloudinaryResponse = new CloudinaryResponse();
            Negocio objeto = new Negocio();

            if(_openFileDialog.FileName != ""){
                cloudinaryResponse = await _cloudinaryService.SubirImagen(_openFileDialog.SafeFileName,_openFileDialog.OpenFile());

                if(cloudinaryResponse.PublicId != ""){
                    if(_negocio.NombreLogo != "")
                        await _cloudinaryService.EliminarImagen(_negocio.NombreLogo!);
                    
                    objeto.NombreLogo = cloudinaryResponse.PublicId;
                    objeto.UrlLogo    = cloudinaryResponse.SecureUrl;

                    _negocio.NombreLogo = cloudinaryResponse.PublicId;
                    _negocio.UrlLogo    = cloudinaryResponse.SecureUrl;
                }
            } else {
                objeto.NombreLogo = _negocio.NombreLogo;
                objeto.UrlLogo    = _negocio.UrlLogo;
            }

            objeto.RazonSocial   = txbRazonSocial.Text;
            objeto.RFC           = txbRfc.Text;
            objeto.Direccion     = txbDireccion.Text;
            objeto.NumCelular    = txbNumCelular.Text;
            objeto.Correo        = txbCorreo.Text;
            objeto.SimboloMoneda = txbSimboloMoneda.Text;

            await _negocioService.Editar(objeto);

            MessageBox.Show("Los datos fueron actualizados.");

            txbRutaImagen.Text = "";
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Escoger imagen(*.JPG;*.PNG)|*.jpg;*.png";
        }

    }
}

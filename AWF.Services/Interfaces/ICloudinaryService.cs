using AWF.Services.Recursos.Cloudinary;

namespace AWF.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<CloudinaryResponse> SubirImagen(string nombreImagen, Stream formatoImagen);
        Task<bool> EliminarImagen(string publicId);
    }
}
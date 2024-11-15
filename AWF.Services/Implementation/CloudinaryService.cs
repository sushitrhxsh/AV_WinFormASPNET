using AWF.Services.Interfaces;
using AWF.Services.Recursos.Cloudinary;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace AWF.Services.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {

        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IConfiguration configuration)
        {
            _configuration = configuration;

            var CloudName = _configuration["Cloudinary:CloudName"];
            var ApiKey    = _configuration["Cloudinary:ApiKey"];
            var ApiSecret = _configuration["Cloudinary:ApiSecret"];

            _cloudinary = new Cloudinary(new Account(CloudName,ApiKey,ApiSecret));
        }

        public async Task<CloudinaryResponse> SubirImagen(string nombreImagen, Stream formatoImagen)
        {
            var cloudinaryResponse = new CloudinaryResponse();
            var uploadParams = new ImageUploadParams(){
                File = new FileDescription(nombreImagen,formatoImagen),
                AssetFolder = "AppWindowsForm"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if(uploadResult.StatusCode == HttpStatusCode.OK){
                cloudinaryResponse.PublicId  = uploadResult.PublicId;
                cloudinaryResponse.SecureUrl = uploadResult.SecureUrl.ToString();
            } else {
                cloudinaryResponse.PublicId = "";
            }

            return cloudinaryResponse;
        }
        
        public async Task<bool> EliminarImagen(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var deleteResult = await _cloudinary.DestroyAsync(deleteParams);

            if(deleteResult.StatusCode == HttpStatusCode.OK)
                return true;
            else 
                return false;  
        }

    }

}
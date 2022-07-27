using Microsoft.AspNetCore.Http;
using UserRegistrationAPI.Data.Attributes;

namespace UserRegistrationAPI.Data.Configurations.Image
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtension(new string[] { ".jpg", ".png" })]
        public IFormFile Image { get; set; }
    }
}


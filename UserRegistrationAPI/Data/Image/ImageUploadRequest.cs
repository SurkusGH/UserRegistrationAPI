using System;
using Microsoft.AspNetCore.Http;
using net17_ImageThumbnail.Attributes;

namespace UserRegistrationAPI.Data.Image
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtension(new string[] { ".jpg", ".png" })]
        public IFormFile Image { get; set; }
    }
}


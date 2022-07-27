using net17_ImageThumbnail.Models;
using System;

namespace UserRegistrationAPI.Services
{
    public interface IImageService
    {
        public ImageObject AddImage(ImageObject image)
        {
            return image;
        }

        public ImageObject LoadImage(Guid id)
        {
            var image = new ImageObject();
            return image;
        }
    }
}

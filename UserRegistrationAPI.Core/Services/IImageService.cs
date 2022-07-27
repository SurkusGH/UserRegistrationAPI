using System;
using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Core.Services
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

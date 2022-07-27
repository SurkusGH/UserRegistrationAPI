using net17_ImageThumbnail.Models;
using System;
using UserRegistrationAPI.Repositories.IRepository;

namespace UserRegistrationAPI.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;

        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }
        public ImageObject AddImage(ImageObject image)
        {
            _repository.SaveImage(image);
            return image;
        }
    }
}

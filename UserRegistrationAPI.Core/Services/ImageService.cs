using UserRegistrationAPI.Core.Repositories.IRepository;
using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Core.Services
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

using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Core.Repositories.IRepository
{
    public interface IImageRepository
    {
        void SaveImage(ImageObject incomingImageObject);
    }
}
using UserRegistrationAPI.Core.Repositories.IRepository;
using UserRegistrationAPI.Data;
using UserRegistrationAPI.Data.Data;

namespace UserRegistrationAPI.Core.Repositories.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly DatabaseContext _db;

        public ImageRepository(DatabaseContext db)
        {
            _db = db;
        }

        public void SaveImage(ImageObject incomingImageObject)
        {
            _db.Add(incomingImageObject);
            _db.SaveChanges();
        }
    }
}


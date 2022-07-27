using Microsoft.EntityFrameworkCore;
using net17_ImageThumbnail.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;
using UserRegistrationAPI.Repositories.IRepository;

namespace UserRegistrationAPI.Repositories.Repository
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


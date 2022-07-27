using net17_ImageThumbnail.Models;
using System;

namespace UserRegistrationAPI.Repositories.IRepository
{
    public interface IImageRepository
    {
        void SaveImage(ImageObject incomingImageObject);
    }
}
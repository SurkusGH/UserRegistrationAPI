using System.IO;
using UserRegistrationAPI.Data.Configurations.Image;

namespace UserRegistrationAPI.Core.Helpers
{
    public class ImageDataParser
    {
        public static byte[] ImageDataToArray_Helper(ImageUploadRequest request)
        {
            using var memoryStream = new MemoryStream();
            request.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var imageBytesSetSize = AdjustImage.ResizeImage(imageBytes);

            return imageBytesSetSize;
        }
    }
}

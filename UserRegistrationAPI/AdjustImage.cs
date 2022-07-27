using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace UserRegistrationAPI
{
    public class AdjustImage
    {
        public static byte[] ResizeImage(byte[] imageBytes)
        {
            using (Image image = Image.Load(imageBytes))
            {
                image.Mutate(x => x.Resize(5, 5));
                var outStream = new MemoryStream();
                image.Save(outStream, new JpegEncoder());
                return outStream.ToArray();
            }
        }
    }
}

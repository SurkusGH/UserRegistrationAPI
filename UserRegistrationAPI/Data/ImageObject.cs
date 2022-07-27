using System;

namespace net17_ImageThumbnail.Models
{
    public class ImageObject
    {
        public Guid Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
    }
}


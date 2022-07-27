using System;

namespace UserRegistrationAPI.Data.Data
{
    public class ImageObject
    {
        public Guid Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
    }
}


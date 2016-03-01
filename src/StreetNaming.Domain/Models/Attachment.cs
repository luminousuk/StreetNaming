using System;
using StreetNaming.Domain.Models.Interfaces;

namespace StreetNaming.Domain.Models
{
    public class Attachment 
        : ICreatable
        , IModifiable
    {
        public long AttachmentId { get; set; }

        public Request Request { get; set; }

        public string OriginalFileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Bytes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
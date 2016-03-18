using System;
using StreetNaming.Domain.Models.Interfaces;

namespace StreetNaming.Domain.Models
{
    public class Attachment 
        : ICreatable
        , IModifiable
    {
        public int AttachmentId { get; set; }

        public int CaseId { get; set; }

        public Case Case { get; set; }

        public string OriginalFileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Bytes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
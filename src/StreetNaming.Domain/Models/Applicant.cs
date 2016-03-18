using System;
using System.Collections.Generic;
using StreetNaming.Domain.Models.Interfaces;

namespace StreetNaming.Domain.Models
{
    public class Applicant
        : ICreatable
        , IModifiable
    {
        public int ApplicantId { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? HouseNumber { get; set; }

        public string HouseName { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }

        public string FullAddress { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public ICollection<Case> Cases { get; set; }
    }
}
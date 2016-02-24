namespace StreetNaming.Domain.Models
{
    public class Applicant
    {
        public long ApplicantId { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }
}
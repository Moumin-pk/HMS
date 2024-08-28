using HMS.Enums;
using HMS.Extensions;

namespace HMS.Models
{

    

    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country { get; set; }

    }

    public class Patient
    {
        public Guid Id { get; set; } = GuidExtensions.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public Guid DoctorId { get; set; }  = GuidExtensions.NewGuid();
        public DateTime AdmissionDate { get; set; }
        public DateTime? DiscahrgeDate { get; set; }
        public Gender Gender { get; set; }

    }


}

using System;
using System.Collections.Generic;

namespace HMS.Data.Models
{
    public partial class Address
    {
        public Address()
        {
            Patients = new HashSet<Patient>();
        }

        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}

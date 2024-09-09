using System;
using System.Collections.Generic;

namespace HMS.Data.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Billings = new HashSet<Billing>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? DoctorId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Billing> Billings { get; set; }
    }
}

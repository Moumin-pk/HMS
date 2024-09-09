using System;
using System.Collections.Generic;

namespace HMS.Data.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Billings = new HashSet<Billing>();
            Patients = new HashSet<Patient>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Specialization { get; set; }
        public int Experience { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public Guid? DepartmentId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Billing> Billings { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}

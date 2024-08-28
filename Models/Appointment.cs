namespace HMS.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctoreId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Purpose { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}

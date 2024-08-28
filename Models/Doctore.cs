using HMS.Enums;

namespace HMS.Models
{

    
    public class Doctore
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public Specialization Specialization { get; set; }
        public int Experience { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
    }
}

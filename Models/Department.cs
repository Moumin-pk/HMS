namespace HMS.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HeadOfDepartment {get; set; }
        public string ContactNumber {  get; set; }
        List<Doctore> Doctors { get; set; }
    }
}

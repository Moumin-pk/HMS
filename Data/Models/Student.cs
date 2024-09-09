using System;
using System.Collections.Generic;

namespace HMS.Data.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
    }
}

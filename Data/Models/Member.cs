using System;
using System.Collections.Generic;

namespace HMS.Data.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int? Experience { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAndSorcerers.Shared
{
    public class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int MaxHealth { get; init; } = 5;
        public int CurrentHealth { get; set; } = 5;
        public int Order { get; set; } = 0;
        public int Chaos { get; set; } = 0;
        public int Math { get; set; } = 1;
        public int Reading { get; set; } = 1;
        public int Writing { get; set; } = 1;
        public int Science { get; set; } = 1;
        public int History { get; set; } = 1;
    }
}

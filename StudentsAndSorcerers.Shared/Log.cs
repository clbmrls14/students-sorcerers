using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAndSorcerers.Shared
{
    public record Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public String StatChanged { get; set; }
        public int StatValue { get; set; }
    }
}

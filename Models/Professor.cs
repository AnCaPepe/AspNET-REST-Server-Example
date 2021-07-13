using System.Collections.Generic;

namespace school_server.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Course> Courses { get; set; }
    }
}
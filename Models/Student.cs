using System.Collections.Generic;

namespace school_server.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<CourseStudent> CourseStudents { get; set; }
    }
}
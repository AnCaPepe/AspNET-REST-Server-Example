namespace school_server.Models
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
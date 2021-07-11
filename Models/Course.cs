namespace school_server.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfessorId { get; set; }
        
        public Professor Professor { get; set; }
    }
}
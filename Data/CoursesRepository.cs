using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using school_server.Models;

namespace school_server.Data
{
    public interface ICoursesRepository : IRetrievesRepository<Course> {}
    public class CoursesRepository : ICoursesRepository
    {
        public DataContext _context { get; }
        public CoursesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Course[]> RetrieveAll()
        {
            return await _context.Courses.OrderBy( x => x.Id ).ToArrayAsync();
        }

        public async Task<Course> Retrieve( int id )
        {
            return await _context.Courses.Where( x => x.Id == id ).FirstOrDefaultAsync();
        }

        public async Task<dynamic> RetrieveDetailed( int id )
        {
            Course result = await Retrieve( id );
            
            if( result != null )
            {
                dynamic course = new ExpandoObject();
                course.id = result.Id;
                course.name = result.Name;

                Professor professor = await _context.Professors.Where( x => x.Id == result.ProfessorId ).FirstOrDefaultAsync();

                course.professor = professor.Name;
                
                course.students = new List<dynamic>();

                CourseStudent[] details = await _context.CourseStudents.Include( x => x.Student )
                                                                       .Where( x => x.CourseId == result.Id ).ToArrayAsync();
                
                foreach( CourseStudent detail in details )
                    course.students.Add( new { id = detail.Student.Id, name = detail.Student.Name } );
                
                return course;
            }

            return null;
        }
    }
}
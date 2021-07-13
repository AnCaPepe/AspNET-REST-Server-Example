using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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

        public async Task<Course> RetrieveDetailed( int id )
        {
            Course result = await Retrieve( id );

            if( result != null )
            {
                result.CourseStudents = await _context.CourseStudents.Include( x => x.Student )
                                                                     .Where( x => x.CourseId == result.Id ).ToListAsync();
            }

            return result;
        }
    }
}
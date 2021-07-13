using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using school_server.Models;

namespace school_server.Data
{
    public interface IStudentsRepository : IRetrievesRepository<Student> {}
    public class StudentsRepository : IStudentsRepository
    {
        public DataContext _context { get; }
        public StudentsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Student[]> RetrieveAll()
        {
            return await _context.Students.OrderBy( x => x.Id ).ToArrayAsync();
        }

        public async Task<Student> Retrieve( int id )
        {
            return await _context.Students.Where( x => x.Id == id ).FirstOrDefaultAsync();
        }

        public async Task<Student> RetrieveDetailed( int id )
        {
            Student result = await Retrieve( id );

            if( result != null )
            {
                result.CourseStudents = await _context.CourseStudents.Include( x => x.Course )
                                                                     .Where( x => x.StudentId == result.Id ).ToListAsync();
            }

            return result;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using school_server.Models;

namespace school_server.Data
{
    public interface IProfessorsRepository : IRetrievesRepository<Professor> {}
    public class ProfessorsRepository : IProfessorsRepository
    {
        private readonly DataContext _context;
        public ProfessorsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Professor[]> RetrieveAll()
        {
            return await _context.Professors.OrderBy( x => x.Id ).ToArrayAsync();
        }

        public async Task<Professor> Retrieve( int id )
        {
            return await _context.Professors.Where( x => x.Id == id ).FirstOrDefaultAsync();

        }

        public async Task<dynamic> RetrieveDetailed( int id )
        {
            Professor result = await Retrieve( id );
            
            if( result != null )
            {
                dynamic professor = new ExpandoObject();
                professor.id = result.Id;
                professor.name = result.Name;
                professor.age = result.Age;
                professor.courses = new List<dynamic>();

                Course[] courses = await _context.Courses.Where( x => x.ProfessorId == result.Id ).ToArrayAsync();
                
                foreach( Course course in courses )
                    professor.courses.Add( new { id = course.Id, name = course.Name } );
                
                return professor;
            }

            return null;
        }
    }
}
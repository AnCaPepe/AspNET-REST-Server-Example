using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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

        public async Task<Professor> RetrieveDetailed( int id )
        {
            Professor result = await Retrieve( id );

            if( result != null )
            {
                result.Courses = await _context.Courses.Where( x => x.ProfessorId == result.Id ).ToListAsync();
            }

            return result;
        }
    }
}
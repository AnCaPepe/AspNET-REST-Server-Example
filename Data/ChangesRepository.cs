using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace school_server.Data
{
    public class ChangesRepository : IChangesRepository
    {
        public DataContext _context { get; }
        public ChangesRepository(DataContext context)
        {
            _context = context;
        }
        public void Create<T>(T entity) where T : class
        {
            _context.Add( entity );
        }
        // T Retrieve<T>( int id ) where T: class;
        public void Update<T>(T entity) where T : class
        {
            _context.Update( entity );
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove( entity );
        }

        public async Task<bool> SaveChanges()
        {

            return ( await _context.SaveChangesAsync() > 0 );
        }
    }
}
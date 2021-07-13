using System.Threading.Tasks;
using System.Collections.Generic;

namespace school_server.Data
{
    public interface IChangesRepository
    {
        void Create<T>( T entity ) where T: class;
        void Update<T>( T entity ) where T: class;
        void Delete<T>( T entity ) where T: class;

        Task<bool> SaveChanges();
    }
}
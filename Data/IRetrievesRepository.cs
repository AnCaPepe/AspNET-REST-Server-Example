using System.Threading.Tasks;
using System.Collections.Generic;

using school_server.Models;

namespace school_server.Data
{
    public interface IRetrievesRepository<T> where T : class
    {
        Task<T[]> RetrieveAll();
        Task<T> Retrieve( int id );
        Task<dynamic> RetrieveDetailed( int id );
    }
}
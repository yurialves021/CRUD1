using Microsoft.EntityFrameworkCore;

namespace CRUD1.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        

        
    }
}

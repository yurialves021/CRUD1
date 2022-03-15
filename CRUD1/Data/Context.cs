using CRUD1.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD1.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


        public DbSet<Client> Cliente { get; set; }

    }
}

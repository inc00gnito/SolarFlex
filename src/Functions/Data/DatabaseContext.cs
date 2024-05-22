using Functions.Models;
using Microsoft.EntityFrameworkCore;

namespace Functions.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt) { }


        public DbSet<BuildingConfiguration> BuildingsConfigurations{ get; set; }
    }
}

using BenchmarkEFCoreDapper.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BenchmarkEFCoreDapper.Data.Factories
{
    public class MigrationsContextFactory : IDesignTimeDbContextFactory<AthleteDbContext>
    {
        public AthleteDbContext CreateDbContext(string[] args)
        {
            return new AthleteDbContext(GetOptions());
        }

        private DbContextOptions<AthleteDbContext> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<AthleteDbContext>();

            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AthleteDB;Trusted_Connection=True;");

            return builder.Options;
        }
    }
}

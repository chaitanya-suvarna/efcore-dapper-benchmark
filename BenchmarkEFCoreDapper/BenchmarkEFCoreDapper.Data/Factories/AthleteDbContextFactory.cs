using BenchmarkEFCoreDapper.Data.Contexts;
using BenchmarkEFCoreDapper.Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkEFCoreDapper.Data.Factories
{
    public class AthleteDBContextFactory : IAthleteDBContextFactory
    {
        public AthleteDbContext Create()
        {
            return new AthleteDbContext(GetOptions());
        }

        public SqlConnection Connection()
        {
            return new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=AthleteDB;Trusted_Connection=True;");
        }

        private DbContextOptions<AthleteDbContext> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<AthleteDbContext>();

            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AthleteDB;Trusted_Connection=True;");

            return builder.Options;
        }
    }
}

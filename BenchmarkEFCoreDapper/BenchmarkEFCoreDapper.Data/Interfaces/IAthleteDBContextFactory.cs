using BenchmarkEFCoreDapper.Data.Contexts;
using Microsoft.Data.SqlClient;

namespace BenchmarkEFCoreDapper.Data.Interfaces
{
    public interface IAthleteDBContextFactory
    {
        SqlConnection Connection();
        AthleteDbContext Create();
    }
}
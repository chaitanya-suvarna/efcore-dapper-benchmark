using System.Threading.Tasks;
using BenchmarkEFCoreDapper.Data.Entities;
using BenchmarkEFCoreDapper.Data.Interfaces;

namespace BenchmarkEFCoreDapper.Data.Repositories
{
    public class AthleteRepository
    {
        private readonly IAthleteDBContextFactory _athleteDBContextFactory;

        public AthleteRepository(IAthleteDBContextFactory athleteDBContextFactory)
        {
            _athleteDBContextFactory = athleteDBContextFactory;
        }

        public async Task InsertAthleteAsync(Athlete athlete)
        {
            using (var context = _athleteDBContextFactory.Create())
            {
                await context.AddAsync(athlete);

                await context.SaveChangesAsync();
            }
        }
    }
}

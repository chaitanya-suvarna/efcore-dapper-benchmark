using BenchmarkDotNet.Attributes;
using BenchmarkEFCoreDapper.Data.Contexts;
using BenchmarkEFCoreDapper.Data.Factories;
using BenchmarkEFCoreDapper.Data.Interfaces;
using BenchmarkEFCoreDapper.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BenchmarkEFCoreDapper
{
    [RankColumn]
    [MemoryDiagnoser]
    public class DatabaseBenchmark
    {
        private readonly ServiceProvider serviceProvider = new ServiceCollection()
                .AddDbContext<AthleteDbContext>(builder => builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AthleteDB;Trusted_Connection=True;"))
                .AddTransient<IAthleteDBContextFactory, AthleteDBContextFactory>()
                .AddTransient<IAthleteRepository, AthleteRepository>()
                .BuildServiceProvider();

        private readonly IAthleteRepository _athleteRepository;

        public DatabaseBenchmark()
        {
            _athleteRepository = serviceProvider.GetService<IAthleteRepository>();
        }

        int numberOfIterations = 100;

        [Benchmark]
        public async Task FetchUsingDapper()
        {
            for (int i=0; i<numberOfIterations; i++)
            {
                await _athleteRepository.GetIndoorAthletesOlderThan25WithDapperAsync().ConfigureAwait(false);
            }
        }

        [Benchmark]
        public void FetchUsingEFCore()
        {
            for (int i = 0; i < numberOfIterations; i++)
            {
                _athleteRepository.GetIndoorAthletesOlderThan25WithEFCore();
            }
        }

        [Benchmark]
        public async Task InsertUsingDapper()
        {
            for (int i = 0; i < numberOfIterations; i++)
            {
                await _athleteRepository.InsertAthleteWithDapperAsync("Tony Helms", 25, 1).ConfigureAwait(false);
            }
        }

        [Benchmark]
        public async Task InsertUsingEFCoreAsync()
        {
            for (int i = 0; i < numberOfIterations; i++)
            {
                await _athleteRepository.InsertAthleteWithEFCoreAsync("Tony Helms", 25, 1).ConfigureAwait(false);
            }
        }
    }
}

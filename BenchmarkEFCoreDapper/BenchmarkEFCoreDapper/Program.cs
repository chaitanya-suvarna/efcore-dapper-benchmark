using BenchmarkDotNet.Running;
using BenchmarkEFCoreDapper.Data.Contexts;
using BenchmarkEFCoreDapper.Data.Factories;
using BenchmarkEFCoreDapper.Data.Interfaces;
using BenchmarkEFCoreDapper.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BenchmarkEFCoreDapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AthleteDbContext>(builder => builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AthleteDB;Trusted_Connection=True;"))
                .AddTransient<IAthleteDBContextFactory, AthleteDBContextFactory>()
                .AddTransient<IAthleteRepository, AthleteRepository>()
                .BuildServiceProvider();

            // do actual work here
            var athleteRepository = serviceProvider.GetService<IAthleteRepository>();

            await athleteRepository.DeleteAllAsync();
            await athleteRepository.InsertAsync();

            var summary = BenchmarkRunner.Run<DatabaseBenchmark>();
        }
    }
}

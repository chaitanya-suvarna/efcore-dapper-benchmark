using System;
using BenchmarkEFCoreDapper.Data.Contexts;
using BenchmarkEFCoreDapper.Data.Factories;
using BenchmarkEFCoreDapper.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BenchmarkEFCoreDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AthleteDbContext>(builder => builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AthleteDB;Trusted_Connection=True;"))
                .AddTransient<IAthleteDBContextFactory, AthleteDBContextFactory>();

            Console.WriteLine("Hello World!");
        }
    }
}

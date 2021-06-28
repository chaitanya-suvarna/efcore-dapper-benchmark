using BenchmarkEFCoreDapper.Data.Entities;
using BenchmarkEFCoreDapper.Data.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchmarkEFCoreDapper.Data.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly IAthleteDBContextFactory _athleteDBContextFactory;

        public AthleteRepository(IAthleteDBContextFactory athleteDBContextFactory)
        {
            _athleteDBContextFactory = athleteDBContextFactory;
        }

        public async Task InsertAsync()
        {
            var sports = BuildSampleData();

            using (var context = _athleteDBContextFactory.Create())
            {
                await context.Sports.AddRangeAsync(sports);

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAllAsync()
        {
            using (var connection = _athleteDBContextFactory.Connection())
            {
                await connection.ExecuteAsync("TRUNCATE TABLE Athletes;");
                await connection.ExecuteAsync("DELETE FROM Sports;");
                await connection.ExecuteAsync("DBCC CHECKIDENT ([Sports], RESEED, 0)");
            }
        }

        public List<string> GetIndoorAthletesOlderThan25WithEFCore()
        {
            using (var context = _athleteDBContextFactory.Create())
            {
                var athletes = context.Athletes
                    .Where(a => a.Age > 25 && a.Sport.SportType == "Indoor")
                    .Select(s => s.Name)
                    .ToList();

                return athletes;
            }
        }

        public async Task<List<string>> GetIndoorAthletesOlderThan25WithDapperAsync()
        {
            var cmd = "Select a.Name from Athletes a with(nolock) inner join Sports s with(nolock) on a.SportId = s.Id " +
                "where a.Age > 25 and s.SportType = 'Indoor'";
            using (var connection = _athleteDBContextFactory.Connection())
            {
                var athleteNames = await connection.QueryAsync<string>(cmd).ConfigureAwait(false);

                return athleteNames.ToList();
            }
        }

        public async Task InsertAthleteWithEFCoreAsync(string name, int age,int sportId)
        {
            var athlete = new Athlete { Name = name, Age = age, SportId = sportId };
            using (var context = _athleteDBContextFactory.Create())
            {
                await context.Athletes.AddAsync(athlete).ConfigureAwait(false);

                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task InsertAthleteWithDapperAsync(string name, int age, int sportId)
        {
            var cmd = $"Insert into Athletes(Name, Age, SportId) values('{name}', {age}, {sportId});";

            using (var connection = _athleteDBContextFactory.Connection())
            {
                await connection.ExecuteAsync(cmd).ConfigureAwait(false);
            }
        }

        private List<Sport> BuildSampleData()
        {
            return new List<Sport>
            {
                new Sport
                {
                    SportName = "Swimming",
                    SportType = "Outdoor",
                    Athletes = new List<Athlete>
                    {
                        new Athlete
                        {
                            Name = "John Smith",
                            Age = 23
                        },
                        new Athlete
                        {
                            Name = "Steve Colins",
                            Age = 25
                        },
                        new Athlete
                        {
                            Name = "Emma Charles",
                            Age = 21
                        }
                    }
                },
                new Sport
                {
                    SportName = "Chess",
                    SportType = "Indoor",
                    Athletes = new List<Athlete>
                    {
                        new Athlete
                        {
                            Name = "Vlad Namikovski",
                            Age = 28
                        },
                        new Athlete
                        {
                            Name = "Stella Carter",
                            Age = 24
                        },
                        new Athlete
                        {
                            Name = "Dennis Stevenson",
                            Age = 22
                        }
                    }
                },
                new Sport
                {
                    SportName = "Table Tennis",
                    SportType = "Indoor",
                    Athletes = new List<Athlete>
                    {
                        new Athlete
                        {
                            Name = "Yamato Akitsuki",
                            Age = 26
                        },
                        new Athlete
                        {
                            Name = "Gabbie Ives",
                            Age = 26
                        },
                        new Athlete
                        {
                            Name = "Alex Philips",
                            Age = 27
                        },
                        new Athlete
                        {
                            Name = "Andrew Scott",
                            Age = 24
                        }
                    }
                },
                new Sport
                {
                    SportName = "Running",
                    SportType = "Outdoor",
                    Athletes = new List<Athlete>
                    {
                        new Athlete
                        {
                            Name = "Sean McMaster",
                            Age = 23
                        },
                        new Athlete
                        {
                            Name = "Lester Stevens",
                            Age = 24
                        }
                    }
                },
                new Sport
                {
                    SportName = "Carrom",
                    SportType = "Indoor",
                    Athletes = new List<Athlete>
                    {
                        new Athlete
                        {
                            Name = "Steve Hoppner",
                            Age = 30
                        },
                        new Athlete
                        {
                            Name = "Shione Davidson",
                            Age = 27
                        },
                        new Athlete
                        {
                            Name = "Karla Vincent",
                            Age = 26
                        },
                        new Athlete
                        {
                            Name = "Edwin East",
                            Age = 29
                        }
                    }
                }
            };
        }
    }
}

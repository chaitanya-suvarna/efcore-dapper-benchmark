using BenchmarkEFCoreDapper.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchmarkEFCoreDapper.Data.Interfaces
{
    public interface IAthleteRepository
    {
        Task DeleteAllAsync();
        Task InsertAsync();
        Task<List<string>> GetIndoorAthletesOlderThan25WithDapperAsync();
        List<string> GetIndoorAthletesOlderThan25WithEFCore();
        Task InsertAthleteWithDapperAsync(string name, int age, int sportId);
        Task InsertAthleteWithEFCoreAsync(string name, int age, int sportId);
    }
}
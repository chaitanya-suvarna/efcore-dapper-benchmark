using System.ComponentModel.DataAnnotations;

namespace BenchmarkEFCoreDapper.Data.Entities
{
    public class Athlete
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        public Sport Sport { get; set; }
    }
}

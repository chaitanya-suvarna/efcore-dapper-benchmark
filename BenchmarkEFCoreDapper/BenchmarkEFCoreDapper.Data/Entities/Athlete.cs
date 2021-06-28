using System.ComponentModel.DataAnnotations;

namespace BenchmarkEFCoreDapper.Data.Entities
{
    public class Athlete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int SportId { get; set; }

        public virtual Sport Sport { get; set; }
    }
}

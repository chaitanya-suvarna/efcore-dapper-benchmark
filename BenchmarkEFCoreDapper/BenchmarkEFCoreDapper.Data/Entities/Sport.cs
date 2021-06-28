using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenchmarkEFCoreDapper.Data.Entities
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string SportName { get; set; }

        [Required]
        [MaxLength(10)]
        public string SportType { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }
    }
}

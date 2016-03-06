using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        [Range(5, 150)]
        public int Age { get; set; }

        public virtual ICollection<Work> Works { get; set; }

    }
}

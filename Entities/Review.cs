using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookva.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }
        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        public int UserId { get; set; }
        public int WorkId { get; set; }


        public virtual User User { get; set; }
        public virtual Work Work { get; set; }
    }
}

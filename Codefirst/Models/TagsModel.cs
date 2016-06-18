using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codefirst.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(400)]
        public string NameTag { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public Tag()
        {
            List<Task> Tasks = new List<Task>();
        }
    }
}

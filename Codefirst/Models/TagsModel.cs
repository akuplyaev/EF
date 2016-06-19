using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codefirst.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(400)]
        public string NameTag { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public Tag()
        {
             Tasks = new HashSet<Task>();
        }
    }
}

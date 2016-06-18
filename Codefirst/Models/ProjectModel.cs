using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codefirst.Models
{
    public class Project
    {
        [Key]       
        public int Id { get; set; }
        
        [Required]
        [MaxLength(400)]
        public string NameProject { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public Project()
        {
            List<Task> Tasks = new List<Task>();
        }
    }
}

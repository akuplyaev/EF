using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codefirst.Models {
    public class Project {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(400)]
        [Required]
        public string NameProject { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
      public  Project() {
            List<Task> Tasks = new List<Task>();
        }
    }
}

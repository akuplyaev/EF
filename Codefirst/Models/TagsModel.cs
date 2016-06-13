using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codefirst.Models {
    public class Tag {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(400)]
        [Required]
        public string NameTag { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public Tag() {
            List<Task> Tasks = new List<Task>();
        }        
    }
}

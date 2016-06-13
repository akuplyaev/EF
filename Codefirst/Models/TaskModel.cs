using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Codefirst.Models {
    public class Task {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GuidId { get; set; }
        [MaxLength(400)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public bool Mark { get; set; }
        public DateTime? Deadline { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        
    }
}

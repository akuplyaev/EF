using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Codefirst.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; } 
             
        [Required]
        [MaxLength(400)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public bool Mark { get; set; }

        public DateTime? Deadline { get; set; }
        
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]     
        public Project Project { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Task()
        {
            Tags = new HashSet<Tag>();
        }

    }
}

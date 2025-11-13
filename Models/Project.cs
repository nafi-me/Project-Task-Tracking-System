using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabProjectTracker.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Domain.Entities
{
    public class Questions : BaseEntity
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int Tier { get; set; }
        [Required]
        public bool IsImportant { get; set; }
        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }
    }
}

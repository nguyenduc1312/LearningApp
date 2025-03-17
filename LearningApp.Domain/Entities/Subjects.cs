using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Domain.Entities
{
    public class Subjects : BaseEntity
    {
        [Required]
        public string Title { get; set; }
    }
}

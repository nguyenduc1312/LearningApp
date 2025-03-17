using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Domain.Entities
{
    public class Answer : BaseEntity
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }
        public Questions Question { get; set; }
    }
}

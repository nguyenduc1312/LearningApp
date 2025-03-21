using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.ReadModels
{
    public class AnswerReadModel : BaseReadModel
    {
        public int AnswerId { get; set; } //Id của sql
        public bool IsTrue { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}

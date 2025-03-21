using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.ReadModels
{
    class QuestionReadModel : BaseReadModel
    {
        public int QuestionId { get; set; }  // Id từ SQL Server
        public int Tier { get; set; }
        public bool IsImportant { get; set; }
        public string Content { get; set; }
        public List<AnswerReadModel> Answers { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubjectId { get; set; }
    }
}

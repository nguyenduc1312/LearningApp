using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.ReadModels
{
    public class SubjectReadModel : BaseReadModel
    {
        public int SubjectId { get; set; }  // Id từ SQL Server
        public string Title { get; set; }
    }
}

using LearningApp.Infrastructure.ReadModels;
using LearningApp.Infrastructure.Repositories.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.Repositories.MongoDB
{
    public class SubjectReadRepository : BaseMongoRepository<SubjectReadModel>, ISubjectReadRepository
    {
        public SubjectReadRepository(IMongoDatabase database) : base(database, "Subjects")
        {

        }
    }
}

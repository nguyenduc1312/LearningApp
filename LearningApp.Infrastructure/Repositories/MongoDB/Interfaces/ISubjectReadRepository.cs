using LearningApp.Infrastructure.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.Repositories.MongoDB.Interfaces
{
    public interface ISubjectReadRepository : IBaseMongoRepository<SubjectReadModel>
    {
    }
}

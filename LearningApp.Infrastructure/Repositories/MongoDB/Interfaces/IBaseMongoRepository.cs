using LearningApp.Infrastructure.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.Repositories.MongoDB.Interfaces
{
    public interface IBaseMongoRepository<T> where T : BaseReadModel
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}

using Microsoft.EntityFrameworkCore;
using LearningApp.Domain.Entities;

namespace LearningApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}

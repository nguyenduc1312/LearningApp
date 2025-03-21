using LearningApp.Domain.Entities;
using LearningApp.Infrastructure.Data;
using LearningApp.Infrastructure.Repositories.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Infrastructure.Repositories.SQL
{
    public class SubjectRepository : Repository<Subjects>, ISubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

using LearningApp.Domain.Entities;
using LearningApp.Infrastructure.Repositories.SQL.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Features.Subject.Commands
{
    public class DeleteSubjectHandler : IRequestHandler<DeleteSubjectCommand, int>
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly ILogger<DeleteSubjectHandler> logger;
        public DeleteSubjectHandler(ISubjectRepository subjectRepository, ILogger<DeleteSubjectHandler> logger)
        {
            this.subjectRepository = subjectRepository;
            this.logger = logger;
        }
        public async Task<int> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await subjectRepository.GetByIdAsync(request.Id);
            if (subject == null)
                throw new ApplicationException("Môn học không tồn tại!");

            try
            {
                subjectRepository.Delete(subject);
                await subjectRepository.SaveChangesAsync();

                return subject.Id;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new ApplicationException("Đã có lỗi xảy ra. Xin thử lại sau.");
            }
        }
    }
}

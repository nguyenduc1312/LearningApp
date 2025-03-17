using AutoMapper;
using LearningApp.Domain.Entities;
using LearningApp.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Features.Subject.Commands
{
    public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectCommand, int>
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly ILogger<UpdateSubjectHandler> logger;
        private readonly IMapper mapper;
        public UpdateSubjectHandler(
            ISubjectRepository subjectRepository, 
            ILogger<UpdateSubjectHandler> logger,
            IMapper mapper)
        {
            this.subjectRepository = subjectRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<int> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await subjectRepository.GetByIdAsync(request.Id);
            if (subject == null)
                throw new ApplicationException("Môn học không tồn tại!");

            try
            {
                subject = mapper.Map<Subjects>(request);

                subjectRepository.Update(subject);
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

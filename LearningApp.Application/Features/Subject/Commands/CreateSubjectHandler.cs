using LearningApp.Application.DTOs;
using LearningApp.Infrastructure.Repositories.Interfaces;
using MediatR;
using LearningApp.Domain.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace LearningApp.Application.Features.Subject.Commands
{
    public class CreateSubjectHandler : IRequestHandler<CreateSubjectCommand, int>
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly ILogger<CreateSubjectHandler> logger;
        private readonly IMapper mapper;
        public CreateSubjectHandler(
            ISubjectRepository subjectRepository, 
            ILogger<CreateSubjectHandler> logger,
            IMapper mapper) 
        {
            this.subjectRepository = subjectRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var checkExists = await subjectRepository.FindAsync(item => item.Title == request.Title);
            if (checkExists?.Count() > 0)
                throw new Exception("Tên môn học đã được đăng ký trước đó!");

            try
            {
                var subject = mapper.Map<Subjects>(request);

                await subjectRepository.AddAsync(subject);
                await subjectRepository.SaveChangesAsync();

                return subject.Id;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new ApplicationException("An error occurred while creating subject. Please try again later.");
            }
        }
    }
}

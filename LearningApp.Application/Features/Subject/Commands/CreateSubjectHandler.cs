using LearningApp.Application.DTOs;
using LearningApp.Infrastructure.Repositories.Interfaces;
using MediatR;
using LearningApp.Domain.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            var checkExists = await subjectRepository.FindAsync(item => item.Title == request.Title, cancellationToken);
            if (checkExists.Any())
            {
                throw new InvalidOperationException("Tên môn học đã được đăng ký trước đó!");
            }

            try
            {
                var subject = mapper.Map<Subjects>(request);

                await subjectRepository.AddAsync(subject, cancellationToken);
                await subjectRepository.SaveChangesAsync(cancellationToken);

                return subject.Id;
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "A database error occurred while creating the subject.");
                throw new ApplicationException("Đã có lỗi xảy ra. Thử lại sau.");
            }
            catch (AutoMapperMappingException ex)
            {
                logger.LogError(ex, "An error occurred while mapping the subject.");
                throw new ApplicationException("Đã có lỗi xảy ra. Thử lại sau.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred while creating the subject.");
                throw new ApplicationException("Đã có lỗi xảy ra. Thử lại sau.");
            }
        }
    }
}

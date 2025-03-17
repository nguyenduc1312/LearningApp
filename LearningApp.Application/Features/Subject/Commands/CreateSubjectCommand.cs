using LearningApp.Application.DTOs;
using LearningApp.Application.Features.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Features.Subject.Commands
{
    public class CreateSubjectCommand : IRequest<int>, IBaseCommand
    {
        public required string Title { get; set; }
    }
}

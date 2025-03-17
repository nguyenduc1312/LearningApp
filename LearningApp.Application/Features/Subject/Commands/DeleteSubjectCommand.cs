using LearningApp.Application.Features.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Features.Subject.Commands
{
    public class DeleteSubjectCommand : IRequest<int>, IBaseCommand
    {
        public int Id { get; set; }
    }
}

using LearningApp.Application.Features.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Features.Subject.Commands
{
    public class UpdateSubjectCommand : IRequest<int>, IBaseCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

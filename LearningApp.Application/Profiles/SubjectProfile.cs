using AutoMapper;
using LearningApp.Application.Features.Subject.Commands;
using LearningApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Application.Profiles
{
    public class SubjectProfile : Profile, IBaseProfile
    {
        public SubjectProfile()
        {
            CreateMap<CreateSubjectCommand, Subjects>().ReverseMap();
            CreateMap<UpdateSubjectCommand, Subjects>().ReverseMap();
            CreateMap<DeleteSubjectCommand, Subjects>().ReverseMap();
        }
    }
}

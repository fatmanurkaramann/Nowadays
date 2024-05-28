using AutoMapper;
using Busineess.DTOs.Company;
using Busineess.DTOs.Employee;
using Busineess.DTOs.Issue;
using Busineess.DTOs.Project;
using Entities;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Company, CreateCompanyDto>()
                .ReverseMap();
            CreateMap<Company, UpdateCompanyDto>()
                .ReverseMap();

            CreateMap<Employee, CreateEmployeeDto>()
                 .ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>()
           .ReverseMap();

            CreateMap<Issue, CreateIssueDto>()
            .ReverseMap();
            CreateMap<Issue, UpdateIssueDto>()
           .ReverseMap();

            CreateMap<Project, CreateProjectDto>()
           .ReverseMap();
            CreateMap<Project, UpdateProjectDto>()
           .ReverseMap();
        }
    }
}

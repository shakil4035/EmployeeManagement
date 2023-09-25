using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pims.Core.CommonModule;
using Pims.Core.Model;
using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModule;
using Pims.Core.ViewModel;
using Pims.Core.ViewModel.Operation_module;
using Pims.Core.ViewModel.Setup_Module;

namespace Pims.Core.AutoMapperConfigarations
{
    public class MappingProfile:Profile
    {
        public override string ProfileName => "MappingProfile";

        public MappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

            CreateMap<Designation, DeginationViewModel>();
            CreateMap<DeginationViewModel, Designation>();

            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<OrganizationViewModel, Organization>();

            CreateMap<University, UniversityViewModel>();
            CreateMap<UniversityViewModel, University>();

            CreateMap<Language, LanguageViewModel>();
            CreateMap<LanguageViewModel, Language>();

            //OperationModule
            CreateMap<GenarelInformation, GenarelInformationViewModel>()
                .ForMember(vm => vm.BirthDate,
                    opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.BirthDate)))
                .ForMember(dto => dto.JobJoiningDate,
                    opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.JobJoiningDate)));

            CreateMap<GenarelInformationViewModel, GenarelInformation>()
                .ForMember(vm => vm.BirthDate,
                    opt => opt.MapFrom(m => DateTimeFormater.StringToDate(m.BirthDate)))
                .ForMember(dto => dto.JobJoiningDate,
                    opt => opt.MapFrom(m => DateTimeFormater.StringToDate(m.JobJoiningDate)));

           CreateMap<EducationInfo,EducationInfoViewModel>()
               .ForMember(vm => vm.PassingYear,
                   opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.PassingYear)))
               .ForMember(dto => dto.PassingYear,
                   opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.PassingYear)));
            CreateMap<EducationInfoViewModel,EducationInfo>()
                .ForMember(vm => vm.PassingYear,
                    opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.PassingYear)))
                .ForMember(dto => dto.PassingYear,
                    opt => opt.MapFrom(m => DateTimeFormater.DateToString(m.PassingYear)));
        }
    }
}

using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Shared.ModelDto;
using InsuranceCompany.Shared.ModelDto.Create;

namespace InsuranceCompany.Shared.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsuranceRequest, InsuranceRequestDto>();

            CreateMap<ClientDto, Client>();
            CreateMap<ClientDto, Client>().ReverseMap();

            CreateMap<InsuranceStatus, InsuranceStatusDto>();
            CreateMap<InsuranceStatus, InsuranceStatusDto>().ReverseMap();


            CreateMap<InsuredPersonDto, InsuredPerson>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client));
            CreateMap<InsuredPersonDto, InsuredPerson>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client)).ReverseMap();

            CreateMap<InsuranceRequestDto, InsuranceRequest>()
                .ForMember(dest => dest.InsuredPersons, opt => opt.MapFrom(src => src.InsuredPersons));  
            CreateMap<InsuranceRequestDto, InsuranceRequest>()
                .ForMember(dest => dest.InsuredPersons, opt => opt.MapFrom(src => src.InsuredPersons)).ReverseMap();

            CreateMap<InsuranceRequestDto, InsuranceRequest>()
                .ForMember(dest => dest.InsuranceStatus, opt => opt.MapFrom(src => src.InsuranceStatus));

            CreateMap<InsuranceRequest, InsuranceRequestDto>()
                .ForMember(dest => dest.MainClient, opt => opt.MapFrom(src => src.InsuredPersons.FirstOrDefault(i => i.IsMainInsuredPerson) != null ? src.InsuredPersons.FirstOrDefault(i => i.IsMainInsuredPerson).Client : null))
                .ForMember(dest => dest.InsuranceStatus, opt => opt.MapFrom(src => src.InsuranceStatus))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost));

            CreateMap<CreateClientDto, Client>();
            CreateMap<CreateInsuranceRateDto, InsuranceRate>();
            CreateMap<CreateInsuranceRequestDto, InsuranceRequest>();

            CreateMap<CreateAnswerDto, Answer>();
            CreateMap<CreateAnswerDto, Answer>().ReverseMap();

            CreateMap<CreateQuestionDto, Question>();
            CreateMap<CreateQuestionDto, Question>().ReverseMap();

            CreateMap<CreateSurveyDto, InsuranceSurvey>();
            CreateMap<CreateSurveyDto, InsuranceSurvey>().ReverseMap();

            CreateMap<InsuranceRateDto, InsuranceRate>();
            CreateMap<InsuranceRateDto, InsuranceRate>().ReverseMap();

            CreateMap<AddSurveyToRateDto, InsuranceTypeSurvey>();
            CreateMap<AddSurveyToRateDto, InsuranceTypeSurvey>().ReverseMap();

            CreateMap<InsuranceTypeSurveyDto, InsuranceTypeSurvey>();
            CreateMap<InsuranceTypeSurveyDto, InsuranceTypeSurvey>().ReverseMap();

            CreateMap<InsuranceSurvey, InsuranceSurveyDto>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.QuestionSurveys.Select(i => i.Question).ToList()));
        }
    }
}

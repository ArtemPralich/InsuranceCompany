using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Shared.ModelDto;
using InsuranceCompany.Shared.ModelDto.Create;
using InsuranceCompany.Shared.ModelDto.Update;

namespace InsuranceCompany.Shared.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsuranceRequest, InsuranceRequestDto>();

            CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.InsuredPersons, opt => opt.Ignore());
            CreateMap<ClientDto, Client>().ReverseMap(); 
            
            CreateMap<AnswerValueDto, AnswerValue>();
            CreateMap<AnswerValueDto, AnswerValue>().ReverseMap();

            CreateMap<InsuranceStatus, InsuranceStatusDto>();
            CreateMap<InsuranceStatus, InsuranceStatusDto>().ReverseMap();

            CreateMap<InsuredPersonDto, InsuredPerson>()
                .ForMember(dest => dest.InsuranceRequest, opt => opt.Ignore());
            CreateMap<InsuredPersonDto, InsuredPerson>().ReverseMap();

            CreateMap<AnswerDto, Answer>();
            CreateMap<AnswerDto, Answer>().ReverseMap();


            CreateMap<InsuranceSurvey, InsuranceSurveyDto>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.QuestionSurveys.Select(i => i.Question).ToList()));
            //CreateMap<InsuranceSurveyDto, InsuranceSurvey>();

            CreateMap<InsuranceRequestDto, InsuranceRequest>()
                .ForMember(dest => dest.InsuranceRate,opt => opt.Ignore())
                .ForMember(dest => dest.InsuranceStatus, opt => opt.MapFrom(src => src.InsuranceStatus));

            CreateMap<InsuranceTypeSurveyDto, InsuranceTypeSurvey>().
                ForMember(dest => dest.InsuranceSurvey, opt => opt.Ignore());

            CreateMap<InsuranceTypeSurveyDto, InsuranceTypeSurvey>().ReverseMap();

            CreateMap<Template, TemplateDto>()
                .ForMember(dest => dest.InsuranceRates, opt => opt.MapFrom(src => src.InsuranceRateTemplates.Select(i => i.InsuranceRateId).Distinct().ToList()));

            CreateMap<InsuranceRateDto, InsuranceRate>()
                .ForMember(dest => dest.InsuranceTypeSurveys, opt => opt.Ignore());
            CreateMap<InsuranceRateDto, InsuranceRate>().ReverseMap();

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

            CreateMap<AddSurveyToRateDto, InsuranceTypeSurvey>();
            CreateMap<AddSurveyToRateDto, InsuranceTypeSurvey>().ReverseMap();

            CreateMap<QuestionDto, Question>();
            CreateMap<QuestionDto, Question>().ReverseMap();

            CreateMap<QuestionTypeDto, QuestionType>();
            CreateMap<QuestionTypeDto, QuestionType>().ReverseMap();

            CreateMap<UpdateAnswerValuesDto, AnswerValue>();
            CreateMap<UpdateClientDto, Client>()
                .ForMember(dest => dest.InsuredPersons, opt => opt.Ignore());
            CreateMap<UpdateInsuranceDto, InsuranceRequest>()
                .ForMember(dest => dest.InsuredPersons, opt => opt.Ignore());
            CreateMap<UpdateInsuredPersonDto, InsuredPerson>()
                .ForMember(dest => dest.InsuranceRequest, opt => opt.Ignore()); ;

            CreateMap<CreateTemplate, Template>();
            CreateMap<UpdateTemplate, Template>();
        }
    }
}

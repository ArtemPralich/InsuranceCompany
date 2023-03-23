using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Shared.ModelDto;

namespace InsuranceCompany.Shared.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsuranceRequest, InsuranceRequestDto>();

        }
    }
}

using AutoMapper;
using StreetNaming.Admin.ViewModels;
using StreetNaming.Domain.Models;

namespace StreetNaming.Admin.AutoMapper
{
    public class StreetNamingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Case, CaseIndexCaseViewModel>()
                .ForMember(dest => dest.CaseType, opts => opts.MapFrom(src =>
                    src.CaseType == CaseType.NewPropertyCase ? "New Property" : "Existing Property"));
        }
    }
}
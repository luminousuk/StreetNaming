using AutoMapper;
using StreetNaming.Admin.ViewModels;
using StreetNaming.Domain.Models;

namespace StreetNaming.Admin.AutoMapper
{
    public class StreetNamingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Case, CaseIndexCaseViewModel>();
        }
    }
}
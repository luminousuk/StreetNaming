using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StreetNaming.Domain.Models;
using StreetNaming.Web.ViewModels;

namespace StreetNaming.Web.AutoMapper
{
    public class StreetNamingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<NewPropertyViewModel, Applicant>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.ApplicantName))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.ApplicantAddress))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.ApplicantEmail))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.ApplicantMobile))
                .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.ApplicantPostcode))
                .ForMember(dest => dest.Telephone, opts => opts.MapFrom(src => src.ApplicantTelephone))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ApplicantTitle));

            CreateMap<ExistingPropertyViewModel, Applicant>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.ApplicantName))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.ApplicantAddress))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.ApplicantEmail))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.ApplicantMobile))
                .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.ApplicantPostcode))
                .ForMember(dest => dest.Telephone, opts => opts.MapFrom(src => src.ApplicantTelephone))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ApplicantTitle));
        }
    }
}

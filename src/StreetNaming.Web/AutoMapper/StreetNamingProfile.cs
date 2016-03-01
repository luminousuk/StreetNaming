using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;
using StreetNaming.Domain.Models;
using StreetNaming.Util.Extensions;
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
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ApplicantTitle))
                .ForMember(dest => dest.CreatedDate, opts => opts.UseValue(DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opts => opts.UseValue(DateTime.Now));

            CreateMap<ExistingPropertyViewModel, Applicant>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.ApplicantName))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.ApplicantAddress))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.ApplicantEmail))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.ApplicantMobile))
                .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.ApplicantPostcode))
                .ForMember(dest => dest.Telephone, opts => opts.MapFrom(src => src.ApplicantTelephone))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ApplicantTitle))
                .ForMember(dest => dest.CreatedDate, opts => opts.UseValue(DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opts => opts.UseValue(DateTime.Now));

            CreateMap<NewPropertyViewModel, Request>()
                .ForMember(dest => dest.RequestType, opts => opts.UseValue(RequestType.NewPropertyRequest))
                .ForMember(dest => dest.CreatedDate, opts => opts.UseValue(DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opts => opts.UseValue(DateTime.Now));

            CreateMap<ExistingPropertyViewModel, Request>()
                .ForMember(dest => dest.RequestType, opts => opts.UseValue(RequestType.ExistingPropertyRequest))
                .ForMember(dest => dest.CreatedDate, opts => opts.UseValue(DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opts => opts.UseValue(DateTime.Now));

            CreateMap<IFormFile, Attachment>()
                .ForMember(dest => dest.OriginalFileName,
                    opts => opts.MapFrom(src => ContentDispositionHeaderValue.Parse(src.ContentDisposition).FileName.Trim('"')))
                .ForMember(dest => dest.Bytes, opts => opts.MapFrom(src => src.OpenReadStream().ToBytes()))
                .ForMember(dest => dest.CreatedDate, opts => opts.UseValue(DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opts => opts.UseValue(DateTime.Now));
        }
    }
}

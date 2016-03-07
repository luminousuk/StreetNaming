using System;
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
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.ApplicantFirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.ApplicantLastName))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.ApplicantAddress))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.ApplicantEmail))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.ApplicantMobile))
                .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.ApplicantPostcode))
                .ForMember(dest => dest.Telephone, opts => opts.MapFrom(src => src.ApplicantTelephone))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ApplicantTitle));

            CreateMap<ExistingPropertyViewModel, Applicant>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.ApplicantFirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.ApplicantLastName))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.ApplicantAddress))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.ApplicantEmail))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.ApplicantMobile))
                .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.ApplicantPostcode))
                .ForMember(dest => dest.Telephone, opts => opts.MapFrom(src => src.ApplicantTelephone))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ApplicantTitle));

            CreateMap<NewPropertyViewModel, Request>()
                .ForMember(dest => dest.RequestType, opts => opts.UseValue(RequestType.NewPropertyRequest));

            CreateMap<ExistingPropertyViewModel, Request>()
                .ForMember(dest => dest.RequestType, opts => opts.UseValue(RequestType.ExistingPropertyRequest));

            CreateMap<IFormFile, Attachment>()
                .ForMember(dest => dest.OriginalFileName,
                    opts =>
                        opts.MapFrom(
                            src => ContentDispositionHeaderValue.Parse(src.ContentDisposition).FileName.Trim('"')))
                .ForMember(dest => dest.Bytes, opts => opts.MapFrom(src => src.OpenReadStream().ToBytes()));

            CreateMap<PaymentResponseViewModel, Transaction>()
                .ForMember(dest => dest.ResponseDate, opts => opts.UseValue(DateTime.Now));
        }
    }
}
﻿using System;
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
                .ForMember(dest => dest.HouseNumber, opts => opts.MapFrom(src => src.ApplicantHouseNameNumber.IsNumeric() ? (int?)int.Parse(src.ApplicantHouseNameNumber) : null))
                .ForMember(dest => dest.HouseName, opts => opts.MapFrom(src => !src.ApplicantHouseNameNumber.IsNumeric() ? src.ApplicantHouseNameNumber : null))
                .ForMember(dest => dest.Street, opts => opts.MapFrom(src => src.ApplicantStreet))
                .ForMember(dest => dest.Town, opts => opts.MapFrom(src => src.ApplicantTown))
                .ForMember(dest => dest.County, opts => opts.MapFrom(src => src.ApplicantCounty))
                .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.ApplicantPostcode.ToUpper()))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.ApplicantEmail))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.ApplicantMobile))
                .ForMember(dest => dest.Telephone, opts => opts.MapFrom(src => src.ApplicantTelephone))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.ApplicantTitle));

            CreateMap<ExistingPropertyViewModel, Applicant>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.ApplicantFirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.ApplicantLastName))
                .ForMember(dest => dest.HouseNumber, opts => opts.MapFrom(src => src.ApplicantHouseNameNumber.IsNumeric() ? (int?)int.Parse(src.ApplicantHouseNameNumber) : null))
                .ForMember(dest => dest.HouseName, opts => opts.MapFrom(src => !src.ApplicantHouseNameNumber.IsNumeric() ? src.ApplicantHouseNameNumber : null))
                .ForMember(dest => dest.Street, opts => opts.MapFrom(src => src.ApplicantStreet))
                .ForMember(dest => dest.Town, opts => opts.MapFrom(src => src.ApplicantTown))
                .ForMember(dest => dest.County, opts => opts.MapFrom(src => src.ApplicantCounty))
                .ForMember(dest => dest.PostCode, opts => opts.MapFrom(src => src.ApplicantPostcode.ToUpper()))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.ApplicantEmail))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.ApplicantMobile))
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
        }
    }
}
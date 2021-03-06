﻿using AutoMapper;
using StreetNaming.Admin.ViewModels;
using StreetNaming.Domain.Models;

namespace StreetNaming.Admin.AutoMapper
{
    public class StreetNamingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Case, CaseListCaseViewModel>()
                .ForMember(dest => dest.CaseType, opts => opts.MapFrom(src =>
                    src.CaseType == CaseType.NewPropertyCase ? "New Property" : "Existing Property"));

            CreateMap<Case, CaseGetViewModel>();

            CreateMap<Attachment, CaseGetAttachmentViewModel>();

            CreateMap<Applicant, ApplicantListApplicantViewModel>()
                .ForMember(dest => dest.CaseCount, opts => opts.MapFrom(src => src.Cases.Count));

            CreateMap<Transaction, TransactionListTransactionViewModel>();

            CreateMap<Case, CaseFollowUpCaseViewModel>();

            CreateMap<Transaction, CaseFollowUpCaseTransactionViewModel>();

            CreateMap<Transaction, CaseGetTransactionViewModel>();
        }
    }
}
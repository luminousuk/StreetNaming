﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.OptionsModel;
using StreetNaming.Domain.Models;
using StreetNaming.Util;
using StreetNaming.Web.Configuration;
using StreetNaming.Web.Models;
using StreetNaming.Web.ViewModels;

namespace StreetNaming.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly StreetNamingEntities _db;
        private readonly IMapper _mapper;
        private readonly IOptions<StreetNamingOptions> _options;

        public FormController(StreetNamingEntities context, IMapper mapper, IOptions<StreetNamingOptions> options)
        {
            _db = context;
            _mapper = mapper;
            _options = options;
        }

        public IActionResult ExistingProperty()
        {
            var viewModel = new ExistingPropertyViewModel
            {
                SignedDate = DateTime.Today.ToString("D"),
                AddressLookupEndpoint = _options.Value.AddressLookup.Endpoint,
                AddressLookupMinChars = _options.Value.AddressLookup.MinChars,
                AddressLookupPageSize = _options.Value.AddressLookup.PageSize,
                ApplicantTitleListItems = new SelectList(_options.Value.ApplicantTitles)
            };
            return View(viewModel);
        }

        public IActionResult NewProperty()
        {
            var viewModel = new NewPropertyViewModel
            {
                SignedDate = DateTime.Today.ToString("D"),
                ApplicantTitleListItems = new SelectList(_options.Value.ApplicantTitles)
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExistingProperty(ExistingPropertyViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // TODO: Match criteria needs to be defined
            var applicant =
                await
                    _db.Applicants.FirstOrDefaultAsync(
                        a =>
                            a.FirstName.Equals(viewModel.ApplicantFirstName) &&
                            a.LastName.Equals(viewModel.ApplicantLastName) &&
                            a.Email.Equals(viewModel.ApplicantEmail));

            if (applicant == null)
            {
                applicant = _mapper.Map<Applicant>(viewModel);
                _db.Applicants.Add(applicant);
            }
            else
                _mapper.Map(viewModel, applicant);

            var request = _mapper.Map<Case>(viewModel);
            request.Applicant = applicant;
            request.CaseStatus = CaseStatus.New;
            request.Reference = Guid.NewGuid();
            _db.Cases.Add(request);

            await _db.SaveChangesAsync();

            request.CustomerReference =
                UniqueReferenceGenerator.GetCaseReference(_options.Value.ExistingPropertyReferencePrefix, request.CaseId);

            await _db.SaveChangesAsync();

            return RedirectToAction("Initiate", "Payment", new {caseReference = request.CustomerReference});
        }

        [HttpPost]
        public async Task<IActionResult> NewProperty(NewPropertyViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // TODO: Match criteria needs to be defined
            var applicant =
                await
                    _db.Applicants.FirstOrDefaultAsync(
                        a =>
                            a.FirstName.Equals(viewModel.ApplicantFirstName) &&
                            a.LastName.Equals(viewModel.ApplicantLastName) &&
                            a.Email.Equals(viewModel.ApplicantEmail));

            if (applicant == null)
            {
                applicant = _mapper.Map<Applicant>(viewModel);
                _db.Applicants.Add(applicant);
            }
            else
                _mapper.Map(viewModel, applicant);

            var request = _mapper.Map<Case>(viewModel);
            request.Applicant = applicant;
            request.CaseStatus = CaseStatus.New;
            request.Reference = Guid.NewGuid();
            _db.Cases.Add(request);

            await _db.SaveChangesAsync();

            request.CustomerReference =
                UniqueReferenceGenerator.GetCaseReference(_options.Value.NewPropertyReferencePrefix, request.CaseId);

            await _db.SaveChangesAsync();

            return RedirectToAction("Initiate", "Payment", new {caseReference = request.CustomerReference});
        }
    }
}
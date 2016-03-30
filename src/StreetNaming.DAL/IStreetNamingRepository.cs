using System.Collections.Generic;
using StreetNaming.DAL.DTO;
using StreetNaming.Domain.Models;

namespace StreetNaming.DAL
{
    public interface IStreetNamingRepository
    {
        int GetActiveCaseCount();

        int GetApplicantCount();

        int GetPendingTransactionCount();

        int GetCaseFollowUpCount();

        ICollection<MonthlyCaseCountDto> GetMonthlyCaseCount();

        ICollection<MonthlyCashflowDto> GetMonthlyCashflow();

        ICollection<Case> GetAllCases();

        ICollection<Case> GetActiveCases();

        ICollection<Case> GetCompletedCases();

        Case GetCase(string reference);

        void UpdateCaseStatus(string reference, CaseStatus status);

        Attachment GetAttachment(string reference, string filename);

        ICollection<Applicant> GetAllApplicants();

        ICollection<Transaction> GetAllTransactions();

        ICollection<Transaction> GetPendingTransactions();
    }
}
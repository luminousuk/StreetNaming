using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreetNaming.DAL.DTO;
using StreetNaming.Domain.Models;

namespace StreetNaming.DAL
{
    public interface IStreetNamingRepository
    {
        int GetActiveCaseCount();

        int GetApplicantCount();

        int GetUnpaidTransactionCount();

        int GetCaseFollowUpCount();

        ICollection<MonthlyCaseCountDto> GetMonthlyCaseCount();

        ICollection<MonthlyCashflowDto> GetMonthlyCashflow();
    }
}

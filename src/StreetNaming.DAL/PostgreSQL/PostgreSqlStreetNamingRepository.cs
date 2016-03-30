using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using StreetNaming.DAL.DTO;
using StreetNaming.Domain.Models;

namespace StreetNaming.DAL.PostgreSQL
{
    public class PostgreSqlStreetNamingRepository : IStreetNamingRepository
    {
        private readonly StreetNamingContext _context;

        public PostgreSqlStreetNamingRepository(StreetNamingContext context)
        {
            _context = context;
        }

        public int GetActiveCaseCount()
        {
            return _context.Cases.Count(c => c.CaseStatus == CaseStatus.Active);
        }

        public int GetApplicantCount()
        {
            return _context.Applicants.Count();
        }

        public int GetPendingTransactionCount()
        {
            return _context.Transactions.Count(t => t.TransactionStatus == TransactionStatus.Pending);
        }

        public int GetCaseFollowUpCount()
        {
            return
                _context.Cases.Count(
                    c =>
                        c.IsRegisteredOwner == false ||
                        c.Transactions.Any(t => t.TransactionStatus == TransactionStatus.Pending) ||
                        c.Transactions.All(
                            t =>
                                t.TransactionStatus != TransactionStatus.Complete &&
                                t.TransactionStatus != TransactionStatus.Refunded));
        }

        public ICollection<MonthlyCaseCountDto> GetMonthlyCaseCount()
        {
            return new List<MonthlyCaseCountDto>();
        }

        public ICollection<MonthlyCashflowDto> GetMonthlyCashflow()
        {
            return new List<MonthlyCashflowDto>();
        }

        public ICollection<Case> GetAllCases()
        {
            return _context.Cases
                .Include(c => c.Applicant)
                .ToList();
        }

        public ICollection<Case> GetActiveCases()
        {
            return _context.Cases
                .Where(c => c.CaseStatus == CaseStatus.Active)
                .Include(c => c.Applicant)
                .ToList();
        }

        public ICollection<Case> GetCompletedCases()
        {
            return _context.Cases
                .Where(c => c.CaseStatus == CaseStatus.Completed)
                .Include(c => c.Applicant)
                .ToList();
        }

        public ICollection<Case> GetFollowUpCases()
        {
            return
                _context.Cases
                    .Where(
                        c =>
                            c.IsRegisteredOwner == false ||
                            c.Transactions.Any(t => t.TransactionStatus == TransactionStatus.Pending) ||
                            c.Transactions.All(
                                t =>
                                    t.TransactionStatus != TransactionStatus.Complete &&
                                    t.TransactionStatus != TransactionStatus.Refunded))
                    .Include(c => c.Applicant)
                    .Include(c => c.Transactions)
                    .ToList();
        }

        public Case GetCase(string reference)
        {
            return _context.Cases
                .Include(c => c.Applicant)
                .Include(c => c.Transactions)
                .Include(c => c.Attachments)
                .FirstOrDefault(c => c.CustomerReference == reference);
        }

        public void UpdateCaseStatus(string reference, CaseStatus status)
        {
            var cas = _context.Cases
                .FirstOrDefault(c => c.CustomerReference == reference);

            if (cas == null)
                throw new ArgumentException("Case reference not found.", nameof(reference));

            cas.CaseStatus = status;

            _context.SaveChanges();
        }

        public Attachment GetAttachment(string reference, string filename)
        {
            return _context.Attachments
                .FirstOrDefault(a => a.Case.CustomerReference == reference && a.OriginalFileName == filename);
        }

        public ICollection<Applicant> GetAllApplicants()
        {
            return _context.Applicants
                .Include(a => a.Cases)
                .ToList();
        }

        public ICollection<Transaction> GetAllTransactions()
        {
            return _context.Transactions
                .Include(t => t.Case)
                .ToList();
        }

        public ICollection<Transaction> GetPendingTransactions()
        {
            return _context.Transactions
                .Where(t => t.TransactionStatus == TransactionStatus.Pending)
                .Include(t => t.Case)
                .ToList();
        }
    }
}
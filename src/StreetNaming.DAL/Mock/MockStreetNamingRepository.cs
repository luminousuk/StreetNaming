using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreetNaming.DAL.DTO;

namespace StreetNaming.DAL.Mock
{
    public class MockStreetNamingRepository : IStreetNamingRepository
    {
        private const int MonthlyCaseMax = 20;
        private const int CashflowMax = 40000;
        private readonly Random _random = new Random();

        public int GetActiveCaseCount()
        {
            return _random.Next(100);
        }

        public int GetApplicantCount()
        {
            return _random.Next(100);
        }

        public int GetUnpaidTransactionCount()
        {
            return _random.Next(100);
        }

        public int GetCaseFollowUpCount()
        {
            return _random.Next(100);
        }

        public ICollection<MonthlyCaseCountDto> GetMonthlyCaseCount()
        {
            return new List<MonthlyCaseCountDto>
            {
                new MonthlyCaseCountDto
                {
                    Month = "Jan",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Feb",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Mar",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Apr",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "May",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Jun",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Jul",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Aug",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Sep",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Oct",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Nov",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                },
                new MonthlyCaseCountDto
                {
                    Month = "Dec",
                    ExistingProperty = _random.Next(MonthlyCaseMax),
                    NewProperty = _random.Next(MonthlyCaseMax)
                }
            };
        }

        public ICollection<MonthlyCashflowDto> GetMonthlyCashflow()
        {
            return new List<MonthlyCashflowDto>
            {
                new MonthlyCashflowDto {Month = "Jan", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Feb", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Mar", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Apr", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "May", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Jun", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Jul", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Aug", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Sep", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Oct", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Nov", Income = (0.01M*_random.Next(CashflowMax))},
                new MonthlyCashflowDto {Month = "Dec", Income = (0.01M*_random.Next(CashflowMax))}
            };
        }
    }
}

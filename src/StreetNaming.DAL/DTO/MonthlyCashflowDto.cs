namespace StreetNaming.DAL.DTO
{
    public struct MonthlyCashflowDto
    {
        public MonthlyCashflowDto(string month, decimal income)
        {
            Month = month;
            Income = income;
        }

        public string Month { get; set; }

        public decimal Income { get; set; }
    }
}
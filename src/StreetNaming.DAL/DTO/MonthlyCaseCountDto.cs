using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetNaming.DAL.DTO
{
    public struct MonthlyCaseCountDto
    {
        public MonthlyCaseCountDto(string month, int newProperty, int existingProperty)
        {
            Month = month;
            NewProperty = newProperty;
            ExistingProperty = existingProperty;
        }

        public string Month { get; set; }

        public int NewProperty { get; set; }

        public int ExistingProperty { get; set; }
    }
}

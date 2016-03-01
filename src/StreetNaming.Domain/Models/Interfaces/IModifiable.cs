using System;

namespace StreetNaming.Domain.Models.Interfaces
{
    public interface IModifiable
    {
        DateTime ModifiedDate { get; set; }
    }
}
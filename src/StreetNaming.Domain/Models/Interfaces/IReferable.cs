using System;

namespace StreetNaming.Domain.Models.Interfaces
{
    public interface IReferable
    {
        Guid Reference { get; set; }
    }
}
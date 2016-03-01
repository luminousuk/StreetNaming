using System;

namespace StreetNaming.Domain.Models.Interfaces
{
    public interface ICreatable
    {
        DateTime CreatedDate { get; set; }
    }
}
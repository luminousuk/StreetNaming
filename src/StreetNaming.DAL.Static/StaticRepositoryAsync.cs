using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreetNaming.Domain;
using StreetNaming.Domain.Models;

namespace StreetNaming.DAL.Static
{
    public class StaticRepositoryAsync : IStreetNamingRepositoryAsync
    {
        public StaticRepositoryAsync()
        {
        }

        public Task Add(Applicant source)
        {
            throw new NotImplementedException();
        }

        public Task Update(long id, Applicant source)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Applicant> Find(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Applicant>> Filter(Func<Applicant, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

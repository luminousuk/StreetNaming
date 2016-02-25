using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetNaming.Domain
{
    public interface IEntityRepositoryAsync<T> where T : class
    {
        Task Add(T source);

        Task Update(long id, T source);

        Task Delete(long id);

        Task<T> Find(long id);

        Task<IEnumerable<T>> Filter(Func<T, bool> predicate);
    }
}
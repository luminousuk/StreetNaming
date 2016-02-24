using System;
using System.Collections.Generic;

namespace StreetNaming.Domain
{
    public interface IEntityRepository<T>
    {
        void Add(T source);

        void Update(long id, T source);

        void Delete(long id);

        T Find(long id);

        IEnumerable<T> Filter(Func<T, bool> predicate);
    }
}
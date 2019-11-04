using System.Collections;
using System.Collections.Generic;

namespace Core.DomainServices
{
    public interface IUser<T>
    {
        IEnumerable<T> getAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}
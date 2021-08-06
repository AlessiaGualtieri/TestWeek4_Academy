using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Academy.Test.Core.Repositories
{
    public interface IRepository<T>
    {
        IList<T> Fetch();
        T GetByID(int id);
        bool Add(T item);
        bool Update(T item);
        bool DeleteById(int id);
    }
}

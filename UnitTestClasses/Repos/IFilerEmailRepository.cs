using System;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTestClasses.Repos
{
    public interface IFilerEmailRepository<T> where T : class
    {
        IQueryable<T> GetList(Expression<Func<T, bool>> where);
    }
}
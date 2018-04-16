using System;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTestClasses.Repos
{
    public class FilerEmailRepository<T> : IFilerEmailRepository<T> where T : class
    {
        public IQueryable<T> GetList(Expression<Func<T, bool>> where)
        {
            return null;
        }
    }
}

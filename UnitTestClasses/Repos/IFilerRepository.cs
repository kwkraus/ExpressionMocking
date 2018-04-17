using System;
using System.Linq.Expressions;
using UnitTestClasses.Entities;

namespace UnitTestClasses.Repos
{
    public interface IFilerRepository
    {
        Filer GetWithNoTracking(Expression<Func<Filer, bool>> where);
    }
}
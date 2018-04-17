using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnitTestClasses.Entities;

namespace UnitTestClasses.Repos
{
    public class FilerRepository : IFilerRepository
    {
        private List<Filer> filers;

        public FilerRepository()
        {
            filers = new List<Filer>()
            {
                new Filer(){ FilerId = 1 },
                new Filer(){ FilerId = 2 },
                new Filer(){ FilerId = 3 },
                new Filer(){ FilerId = 4 },
                new Filer(){ FilerId = 100 },
            };
        }

        public Filer GetWithNoTracking(Expression<Func<Filer, bool>> where)
        {

            return filers.AsQueryable().Where(where).FirstOrDefault();
        }
    }
}

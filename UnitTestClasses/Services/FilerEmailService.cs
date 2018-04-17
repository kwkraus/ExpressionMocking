using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnitTestClasses.Entities;
using UnitTestClasses.Repos;

namespace UnitTestClasses.Services
{
    public class FilerEmailService
    {
        private readonly IFilerEmailRepository<FilerEmail> _feRepo;
        private readonly IFilerRepository _fRepo;
        private Filer filer;

        public FilerEmailService(
            IFilerEmailRepository<FilerEmail> feRepo,
            IFilerRepository fRepo)
        {
            _feRepo = feRepo;
            _fRepo = fRepo;
        }

        public string UpdateUserProfileInternal(
            int userId, 
            string changedEmailAddress, 
            int originalStatusId)
        {
            filer = _fRepo.GetWithNoTracking(f => f.FilerId == userId);

            var eUserMailRecord = this.GetFilerEmail
                (c => c.FilerId == filer.FilerId && c.isDefault == true)
                .FirstOrDefault();

            return eUserMailRecord.Email;
        }

        public IEnumerable<FilerEmail> GetFilerEmail(Expression<Func<FilerEmail, bool>> where)
        {
            return _feRepo.GetList(where);
        }
    }
}

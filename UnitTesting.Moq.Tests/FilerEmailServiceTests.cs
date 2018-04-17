using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnitTestClasses.Entities;
using UnitTestClasses.Repos;
using UnitTestClasses.Services;

namespace UnitTesting.Moq.Tests
{
    [TestClass]
    public class FilerEmailServiceTests
    {
        [TestMethod]
        public void FilerEmailService_GetListById_Expression_Test()
        {
            //https://stackoverflow.com/questions/20364107/moq-lambda-expressions-as-parameters-and-evaluate-them-in-returns

            // Arrange
            var feList = new List<FilerEmail>
            {
                new FilerEmail() { isDefault = true, Email = "primary@email.com", FilerId = 1 },
                new FilerEmail() { isDefault = false, Email = "nonprimary@email.com", FilerId = 2 },
                new FilerEmail() { isDefault = true, Email = "2ndprimary@email.com", FilerId = 3 },
                new FilerEmail() { isDefault = true, Email = "myprimary@email.com", FilerId = 100 }
            };

            var filerEmailRepository = new Mock<IFilerEmailRepository<FilerEmail>>();

            filerEmailRepository
                .Setup(fr => fr.GetList(It.IsAny<Expression<Func<FilerEmail, bool>>>()))
                .Returns(new Func<Expression<Func<FilerEmail, bool>>, IQueryable<FilerEmail>>(
                 expr => feList.AsQueryable().Where(expr.Compile()).AsQueryable()));

            var svc = new FilerEmailService(
                filerEmailRepository.Object, 
                new FilerRepository());

            // Act
            var fid = 3;
            var resultsById = svc.UpdateUserProfileInternal(fid, "", 0);

            // Assert
            Assert.IsTrue(resultsById == "2ndprimary@email.com");
        }
    }
}

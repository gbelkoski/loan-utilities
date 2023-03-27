using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FinanceUtilities.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core.Tests
{
    [TestClass]
    public class BankServiceTests : UnitTestBase
    {
        IQueryable<Bank> data = new List<Bank>
            {
                new Bank { Name = "Stopanska" },
                new Bank { Name = "Komercijalna" },
                new Bank { Name = "Silk Road" },
            }.AsQueryable();

        IBankService subject;
        Mock<DbSet<Bank>> mockDbSet;
        Mock<IFinanceContext> mockDbContext;

        [TestInitialize]
        public void Init()
        {
            mockDbSet = new Mock<DbSet<Bank>>();
            mockDbSet.As<IQueryable<Bank>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Bank>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Bank>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Bank>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockDbContext = new Mock<IFinanceContext>();
            mockDbContext.Setup(m => m.Banks).Returns(mockDbSet.Object);
            subject = new BankService(mockDbContext.Object);
        }

        [TestMethod]
        public void SaveBank()
        {
            var result = subject.Save(new Bank()
            {
                Name = "Komercijalna banka",
                ContactPerson = "Grujo",
                Address = "Na vardar",
                ContactPersonEmail = "grujo@seznajko.com",
                Website = "www.kb.com.mk",
                NameEn = "Komercijalna na engleski"
            });

            Assert.IsTrue(result);

            mockDbSet.Verify(m => m.Add(It.IsAny<Bank>()), Times.Once());
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetAllBanks()
        {
            var banks = subject.GetAll();

            Assert.AreEqual(3, banks.Count);
            Assert.AreEqual("Stopanska", banks[0].Name);
            Assert.AreEqual("Komercijalna", banks[1].Name);
            Assert.AreEqual("Silk Road", banks[2].Name);
        }
    }
}

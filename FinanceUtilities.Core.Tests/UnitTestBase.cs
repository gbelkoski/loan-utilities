using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FinanceUtilities.Core.Tests
{
    public class UnitTestBase
    {
        public MockRepository MockRepository { get; private set; }

        [TestInitialize]
        public void UnitTestBaseSetUp()
        {
            MockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Empty };
        }

        [TestCleanup]
        public void VerifyAndTearDown()
        {
            MockRepository.VerifyAll();
        }
    }
}

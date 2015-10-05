namespace StyleCop.Baboon.Tests.Analyzer
{
    using System;
    using NUnit.Framework;
    using StyleCop.Baboon.Analyzer;
    using StyleCop.Baboon.Tests.TestHelper;

    [TestFixture]
    public class ViolationListTest
    {
        private ViolationList list;

        [SetUp]
        public void Init()
        {
            this.list = new ViolationList();
        }

        [Test]
        public void AddViolationForFile()
        {
            var expectedNumberOfViolationsPerFile = 1;

            this.list.AddViolationToFile(ViolationSource.ViolationFileName, ViolationSource.FirstViolation);

            var violationsFound = this.list.GetTotalViolationsForFile(ViolationSource.ViolationFileName);

            Assert.AreEqual(expectedNumberOfViolationsPerFile, violationsFound);
        }

        [Test]
        public void AddViolationForFileAppendNewViolationToSameFile()
        {
            var expectedNumberOfViolationsPerFile = 2;

            this.list.AddViolationToFile(ViolationSource.ViolationFileName, ViolationSource.FirstViolation);
            this.list.AddViolationToFile(ViolationSource.ViolationFileName, ViolationSource.SecondViolation);

            var violationsFound = this.list.GetTotalViolationsForFile(ViolationSource.ViolationFileName);

            Assert.AreEqual(expectedNumberOfViolationsPerFile, violationsFound);
        }
    }
}

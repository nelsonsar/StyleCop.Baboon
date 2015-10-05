namespace StyleCop.Baboon.Tests.Analyzer
{
    using System;
    using NUnit.Framework;
    using StyleCop.Baboon.Analyzer;

    [TestFixture]
    public class ViolationTest
    {
        [Test]
        public void ToStringReturnsViolationAsLine()
        {
            var expectedResult = "Line 666: [SA666] You cannot do this.";

            var violation = new Violation("SA666", "You cannot do this.", 666);

            Assert.AreEqual(expectedResult, violation.ToString());
        }
    }
}

namespace StyleCop.Baboon.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using StyleCop.Baboon.Analyzer;
    using StyleCop.Baboon.Renderer;
    using StyleCop.Baboon.Tests.TestHelper;

    [TestFixture]
    public class ConsoleRendererTest
    {
        [Test]
        public void RenderViolationList()
        {
            var expectedViolationMessage = "Line 666: [SA666] You can't do this.";

            var outputWriter = new Mock<IOutputWriter>();

            var renderer = new ConsoleRenderer(outputWriter.Object);

            renderer.RenderViolationList(WithOneViolation());

            outputWriter.Verify(o => o.WriteLine("StyleCop.Baboon by Nelson Senna."), Times.Once);
            outputWriter.Verify(o => o.WriteLineWithSeparator("File: Test.cs", string.Empty), Times.Once);
            outputWriter.Verify(o => o.WriteColoredLine(expectedViolationMessage, ConsoleColor.DarkRed), Times.Once);
            outputWriter.Verify(o => o.WriteLine("Violations found: 1"), Times.Once);
            outputWriter.Verify(o => o.WriteLineWithSeparator("Files analyzed: 1, Total violations: 1", string.Empty), Times.Once);
        }

        [Test]
        public void OutputsOnlySummaryWhenNoViolationFound()
        {
            var outputWriter = new Mock<IOutputWriter>();

            var renderer = new ConsoleRenderer(outputWriter.Object);

            renderer.RenderViolationList(WithNoViolation());

            outputWriter.Verify(o => o.WriteLine("StyleCop.Baboon by Nelson Senna."), Times.Once);
            outputWriter.Verify(o => o.WriteLineWithSeparator("No violations found! Great job!", string.Empty), Times.Once);
        }

        private static ViolationList WithOneViolation()
        {
            var violationList = new ViolationList();
            violationList.AddViolationToFile(ViolationSource.ViolationFileName, ViolationSource.FirstViolation);

            return violationList;
        }

        private static ViolationList WithNoViolation()
        {
            return new ViolationList();
        }
    }
}

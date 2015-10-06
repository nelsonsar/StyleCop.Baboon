namespace StyleCop.Baboon.Tests
{
    using System;
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    public class ProgramTest
    {
        private Stream output;
        private TextWriter outputWriter;
        private TextWriter currentOutputWriter;
        private TextReader outputReader;

        [Test]
        public void ExitsWithErrorWhenArgumentIsNotPresent()
        {
            var expectedMessage = @"
Usage:
StyleCop.Baboon.exe [stylecop-settings-path] [path-to-analyze]
";
            this.RedirectOutput();
            var result = MainClass.Main(new string[] { "." });
            var message = this.ReadGeneratedOutput();

            Assert.AreEqual(1, result);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void ExitsWithErrorWhenStyleCopSettingsSpecifiedPathDoesNotExist()
        {
            var expectedMessage = @"
Given settings file does not exist. Exiting...
";
            this.RedirectOutput();
            var result = MainClass.Main(new string[] { "/foo/StyleCop.Settings", "." });
            var message = this.ReadGeneratedOutput();

            Assert.AreEqual(2, result);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void ExitsWithErrorWhenSpecifiedPathToAnalyzeDoesNotExist()
        {
            var expectedMessage = @"
Given path to analyze does not exist. Exiting...
";
            this.RedirectOutput();
            var dir = Directory.GetCurrentDirectory();
            var styleCopSettingsPath = string.Format("{0}{1}", dir, "/../../../Settings.StyleCop");
            var result = MainClass.Main(new string[] { styleCopSettingsPath, "/foo/bar" });
            var message = this.ReadGeneratedOutput();

            Assert.AreEqual(3, result);
            Assert.AreEqual(expectedMessage, message);
        }

        private void RedirectOutput()
        {
            this.output = new MemoryStream();
            this.outputWriter = new StreamWriter(output);
            this.currentOutputWriter = System.Console.Out;

            System.Console.SetOut(this.outputWriter);
        }

        private string ReadGeneratedOutput()
        {
            this.outputReader = new StreamReader(output);
            this.outputWriter.Flush();
            this.output.Seek(0, SeekOrigin.Begin);
            var message = this.outputReader.ReadToEnd();
            System.Console.SetOut(this.currentOutputWriter);
            this.outputWriter.Close();

            return message;
        }
    }
}

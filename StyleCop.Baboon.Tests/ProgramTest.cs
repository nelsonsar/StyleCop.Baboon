namespace StyleCop.Baboon.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using NUnit.Framework;

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
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Usage: StyleCop.Baboon.exe [stylecop-settings-path] [path-to-analyze] [ignored-paths]");
            stringBuilder.Append(Environment.NewLine);
            var expectedMessage = stringBuilder.ToString();

            this.RedirectOutput();
            var result = MainClass.Main(new string[] { "." });
            var message = this.ReadGeneratedOutput();

            Assert.AreEqual(1, result);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void ExitsWithErrorWhenStyleCopSettingsSpecifiedPathDoesNotExist()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("Given settings file does not exist. Exiting...");
            stringBuilder.Append(Environment.NewLine);
            var expectedMessage = stringBuilder.ToString();

            this.RedirectOutput();
            var result = MainClass.Main(new string[] { "/foo/StyleCop.Settings", ".", "./obj" });
            var message = this.ReadGeneratedOutput();

            Assert.AreEqual(2, result);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void ExitsWithErrorWhenSpecifiedPathToAnalyzeDoesNotExist()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("Given path to analyze does not exist. Exiting...");
            stringBuilder.Append(Environment.NewLine);
            var expectedMessage = stringBuilder.ToString();

            this.RedirectOutput();
            var dir = Directory.GetCurrentDirectory();
            var styleCopSettingsPath = string.Format("{0}{1}", dir, "/../../../Settings.StyleCop" );
            var result = MainClass.Main(new string[] { styleCopSettingsPath, "/foo/bar", "./obj"  });
            var message = this.ReadGeneratedOutput();

            Assert.AreEqual(3, result);
            Assert.AreEqual(expectedMessage, message);
        }

        private void RedirectOutput()
        {
            this.output = new MemoryStream();
            this.outputWriter = new StreamWriter(this.output);
            this.currentOutputWriter = System.Console.Out;

            System.Console.SetOut(this.outputWriter);
        }

        private string ReadGeneratedOutput()
        {
            this.outputReader = new StreamReader(this.output);
            this.outputWriter.Flush();
            this.output.Seek(0, SeekOrigin.Begin);
            var message = this.outputReader.ReadToEnd();
            System.Console.SetOut(this.currentOutputWriter);
            this.outputWriter.Close();

            return message;
        }
    }
}

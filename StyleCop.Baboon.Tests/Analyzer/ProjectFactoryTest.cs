namespace StyleCop.Baboon.Tests.Analyzer
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using StyleCop.Baboon.Analyzer;

    [TestFixture]
    public class ProjectFactoryTest
    {
        private const string FirstFile = "Test.cs";
        private const string SecondFile = "Test2.cs";
        private const string Settings = "Settings.StyleCop";
        private const string SingleFileProjectPath = FirstFile;
        private const string MultiFileProjectPath = "./src";
        private const string IgnoredPath = "./obj";

        private Mock<IFileSystemHandler> fileSystemHandler;

        [SetUp]
        public void Init()
        {
            this.fileSystemHandler = new Mock<IFileSystemHandler>();
        }

        [Test]
        public void CreateFromPathWithCustomSettingsForSingleFileProject()
        {
            var expectedProject = new Project(SingleFileProjectPath, new List<string> { FirstFile }, Settings);

            this.fileSystemHandler.Setup(f => f.IsDirectory(SingleFileProjectPath)).Returns(false);

            var factory = new ProjectFactory(this.fileSystemHandler.Object);

            var project = factory.CreateFromPathWithCustomSettings(SingleFileProjectPath, Settings, new []{ IgnoredPath });

            this.AssertProjectsAreEqual(expectedProject, project);
        }

        [Test]
        public void CreateFromPathWithCustomSettingsForMultiFileProject()
        {
            var expectedProject = new Project(MultiFileProjectPath, new List<string> { FirstFile, SecondFile }, Settings);

            this.fileSystemHandler.Setup(f => f.IsDirectory(MultiFileProjectPath)).Returns(true);

            this.fileSystemHandler.Setup(f => f.GetAllSourceCodeFiles(MultiFileProjectPath))
                .Returns(new List<string> { FirstFile, SecondFile });

            var factory = new ProjectFactory(this.fileSystemHandler.Object);

            var project = factory.CreateFromPathWithCustomSettings(MultiFileProjectPath, Settings, new []{ IgnoredPath });

            this.AssertProjectsAreEqual(expectedProject, project);
        }

        private void AssertProjectsAreEqual(Project expected, Project actual)
        {
            Assert.AreEqual(expected.Settings, actual.Settings, "Projects settings do not match");
            Assert.AreEqual(expected.Path, actual.Path, "Projects path do not match");
            Assert.AreEqual(expected.Files.Count, actual.Files.Count, "Projects number of files do not match");
        }
    }
}

namespace StyleCop.Baboon.Analyzer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProjectFactory : IProjectFactory
    {
        private readonly IFileSystemHandler fileSystemHandler;

        public ProjectFactory(IFileSystemHandler fileSystemHandler)
        {
            this.fileSystemHandler = fileSystemHandler;
        }

        public Project CreateFromPathWithCustomSettings(string path, string settings, string[] ignoredPaths)
        {
            var fileList = new List<string>();
            if (false == this.fileSystemHandler.IsDirectory(path))
            {
                fileList.Add(path);

                return new Project(path, fileList, settings);
            }

            var allSourceCodeFiles = this.fileSystemHandler.GetAllSourceCodeFiles(path);
            var filteredSourceCodeFiles = allSourceCodeFiles.Where(
                sourceCodeFileName => false == ignoredPaths.Any(sourceCodeFileName.StartsWith));
            fileList.AddRange(filteredSourceCodeFiles);

            return new Project(path, fileList, settings);
        }
    }
}

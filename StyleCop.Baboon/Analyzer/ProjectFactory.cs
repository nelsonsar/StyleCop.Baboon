namespace StyleCop.Baboon.Analyzer
{
    using System;
    using System.Collections.Generic;

    public class ProjectFactory : IProjectFactory
    {
        private readonly IFileSystemHandler fileSystemHandler;

        public ProjectFactory(IFileSystemHandler fileSystemHandler)
        {
            this.fileSystemHandler = fileSystemHandler;
        }

        public Project CreateFromPathWithCustomSettings(string path, string settings)
        {
            var fileList = new List<string>();
            if (false == this.fileSystemHandler.IsDirectory(path))
            {
                fileList.Add(path);

                return new Project(path, fileList, settings);
            }

            fileList.AddRange(this.fileSystemHandler.GetAllSourceCodeFiles(path));

            return new Project(path, fileList, settings);
        }
    }
}

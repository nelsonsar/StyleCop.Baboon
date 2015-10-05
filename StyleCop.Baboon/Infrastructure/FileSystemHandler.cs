namespace StyleCop.Baboon.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using StyleCop.Baboon.Analyzer;

    public class FileSystemHandler : IFileSystemHandler
    {
        private const string SourceFileExtensionPattern = "*.cs";

        public bool IsDirectory(string path)
        {
            if (this.Exists(path))
            {
                var fileAttributes = File.GetAttributes(path);

                return fileAttributes.HasFlag(FileAttributes.Directory);
            }

            return false;
        }

        public bool Exists(string path)
        {
            return Directory.Exists(path) || File.Exists(path);
        }

        public IEnumerable<string> GetAllSourceCodeFiles(string path)
        {
            if (this.Exists(path))
            {
                return Directory.EnumerateFiles(path, SourceFileExtensionPattern, SearchOption.AllDirectories);
            }

            return new List<string>();
        }
    }
}

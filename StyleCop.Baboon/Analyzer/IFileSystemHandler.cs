namespace StyleCop.Baboon.Analyzer
{
    using System;
    using System.Collections.Generic;

    public interface IFileSystemHandler
    {
        bool IsDirectory(string path);

        bool Exists(string path);

        IEnumerable<string> GetAllSourceCodeFiles(string path);
    }
}

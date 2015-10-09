namespace StyleCop.Baboon.Analyzer
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Project
    {
        private readonly string path;
        private readonly IList<string> projectFiles;
        private readonly string settings;

        public Project(string path, IList<string> projectFiles, string settings)
        {
            this.path = path;
            this.projectFiles = projectFiles;
            this.settings = settings;
        }

        public string Path
        {
            get
            {
                return this.path;
            }
        }

        public ReadOnlyCollection<string> Files
        {
            get
            {
                return new ReadOnlyCollection<string>(this.projectFiles);
            }
        }

        public string Settings
        {
            get
            {
                return this.settings;
            }
        }
    }
}

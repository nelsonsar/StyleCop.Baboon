namespace StyleCop.Baboon.Analyzer
{
    using System;
    using System.Collections.Generic;

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

        public IList<string> Files
        {
            get
            {
                return this.projectFiles;
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

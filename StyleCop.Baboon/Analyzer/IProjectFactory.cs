namespace StyleCop.Baboon.Analyzer
{
    using System;

    public interface IProjectFactory
    {
        Project CreateFromPathWithCustomSettings(string path, string settings);
    }
}

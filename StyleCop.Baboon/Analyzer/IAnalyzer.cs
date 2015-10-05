namespace StyleCop.Baboon.Analyzer
{
    using System;
    using System.Collections.Generic;

    public interface IAnalyzer
    {
        ViolationList GetViolationsFromProject(Project project);
    }
}

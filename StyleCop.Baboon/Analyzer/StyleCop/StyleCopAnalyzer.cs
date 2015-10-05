namespace StyleCop.Baboon.Analyzer.StyleCop
{
    using System;
    using System.Collections.Generic;

    public class StyleCopAnalyzer : IAnalyzer
    {
        private ViolationList violations;

        public ViolationList GetViolationsFromProject(Project project)
        {
            this.violations = new ViolationList();
            var styleCopProject = new CodeProject(0, project.Path, new Configuration(null));
            var console = new StyleCopConsole(project.Settings, false, null, null, true);

            foreach (var file in project.Files)
            {
                console.Core.Environment.AddSourceCode(styleCopProject, file, null);
            }

            console.ViolationEncountered += this.OnViolationEncountered;
            console.Start(new[] { styleCopProject }, true);
            console.ViolationEncountered -= this.OnViolationEncountered;

            return this.violations;
        }

        private void OnViolationEncountered(object sender, ViolationEventArgs e)
        {
            if (e.SourceCode != null)
            {
                var violation = new Violation(e.Violation.Rule.CheckId, e.Message, e.LineNumber);
                this.violations.AddViolationToFile(e.SourceCode.Path, violation);
            }
        }
    }
}

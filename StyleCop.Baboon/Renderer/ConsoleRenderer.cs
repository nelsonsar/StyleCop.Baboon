namespace StyleCop.Baboon.Renderer
{
    using System;
    using System.Collections.Generic;
    using StyleCop.Baboon.Analyzer;

    public class ConsoleRenderer : IRenderer
    {
        private readonly IOutputWriter outputWriter;

        public ConsoleRenderer(IOutputWriter outputWriter)
        {
            this.outputWriter = outputWriter;
        }

        public void RenderViolationList(ViolationList violationList)
        {
            this.outputWriter.WriteLine("StyleCop.Baboon by Nelson Senna.");
            var totalViolations = 0;

            foreach (var violation in violationList.Violations)
            {
                var fileName = violation.Key;
                var numberOfViolations = violationList.GetTotalViolationsForFile(fileName);
                totalViolations += numberOfViolations;

                this.outputWriter.WriteLineWithSeparator(string.Format("File: {0}", fileName), string.Empty);

                this.RenderViolationsPerFile(violation.Value);

                this.outputWriter.WriteLine(string.Format("Violations found: {0}", numberOfViolations));
            }

            this.RenderSummary(totalViolations, violationList.TotalFilesAnalyzed);
        }

        private void RenderViolationsPerFile(IList<Violation> violations)
        {
            foreach (var v in violations)
            {
                this.RenderViolation(v);
            }
        }

        private void RenderViolation(Violation violation)
        {
            this.outputWriter.WriteColoredLine(violation.ToString(), ConsoleColor.DarkRed);
        }

        private void RenderSummary(int totalViolations, int numberOfFilesAnalyzed)
        {
            string summary;

            if (totalViolations == 0)
            {
                summary = string.Format("No violations found! Great job!");
            }
            else
            {
                summary = string.Format("Files analyzed: {0}, Total violations: {1}", numberOfFilesAnalyzed, totalViolations);
            }

            this.outputWriter.WriteLineWithSeparator(summary, string.Empty);
        }
    }
}

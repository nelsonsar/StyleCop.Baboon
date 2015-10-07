namespace StyleCop.Baboon.Renderer
{
    using System;
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
                this.outputWriter.WriteLineWithSeparator(string.Format("File: {0}", fileName), string.Empty);

                foreach (var v in violation.Value)
                {
                    this.outputWriter.WriteColoredLine(v.ToString(), ConsoleColor.DarkRed);
                }

                var numberOfViolations = violationList.GetTotalViolationsForFile(fileName);
                this.outputWriter.WriteLine(string.Format("Violations found: {0}", numberOfViolations));

                totalViolations += numberOfViolations;
            }

            string summary;
            if (totalViolations == 0)
            {
                summary = string.Format("No violations found! Great job!");
            }
            else
            {
                summary = string.Format("Files analyzed: {0}, Total violations: {1}", violationList.Violations.Keys.Count, totalViolations);
            }

            this.outputWriter.WriteLineWithSeparator(summary, string.Empty);
        }
    }
}

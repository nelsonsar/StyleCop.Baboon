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
            foreach (var violation in violationList.Violations)
            {
                var fileName = violation.Key;
                this.outputWriter.WriteLine(string.Format("File: {0}", fileName));

                foreach (var v in violation.Value)
                {
                    this.outputWriter.WriteColoredLine(v.ToString(), ConsoleColor.DarkRed);
                }

                var numberOfViolations = violationList.GetTotalViolationsForFile(fileName);
                this.outputWriter.WriteLine(string.Format("Violations found: {0}", numberOfViolations));
                this.outputWriter.WriteLine(string.Empty);
            }
        }
    }
}

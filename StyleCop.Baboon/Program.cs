namespace StyleCop.Baboon
{
    using System;
    using StyleCop.Baboon.Analyzer;
    using StyleCop.Baboon.Analyzer.StyleCop;
    using StyleCop.Baboon.Infrastructure;
    using StyleCop.Baboon.Renderer;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var settings = "";
            var projectPath = "";
            ProcessFile(settings, projectPath);
        }

        private static int ProcessFile(string settings, string projectPath)
        {
            var analyzer = new StyleCopAnalyzer();
            var projectFactory = new ProjectFactory(new FileSystemHandler());
            var project = projectFactory.CreateFromPathWithCustomSettings(projectPath, settings);
            var violations = analyzer.GetViolationsFromProject(project);

            var renderer = new ConsoleRenderer(new StandardOutputWriter());

            renderer.RenderViolationList(violations);

            return 0;
        }
    }
}

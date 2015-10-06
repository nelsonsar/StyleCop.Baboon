namespace StyleCop.Baboon
{
    using System;

    public interface IOutputWriter
    {
        void WriteLine(string line);

        void WriteColoredLine(string line, ConsoleColor color);

        void WriteLineWithSeparator(string line, string separator);
    }
}

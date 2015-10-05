namespace StyleCop.Baboon.Analyzer
{
    using System;

    public class Violation
    {
        private readonly string id;
        private readonly string message;
        private readonly int lineNumber;

        public Violation(string id, string message, int lineNumber)
        {
            this.id = id;
            this.message = message;
            this.lineNumber = lineNumber;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public int LineNumber
        {
            get
            {
                return this.lineNumber;
            }
        }

        public override string ToString()
        {
            return string.Format(string.Format("Line {0}: [{1}] {2}", this.LineNumber, this.Id, this.Message));
        }
    }
}

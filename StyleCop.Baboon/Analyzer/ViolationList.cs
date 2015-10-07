namespace StyleCop.Baboon.Analyzer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ViolationList
    {
        private IDictionary<string, IList<Violation>> violations;

        public ViolationList()
        {
            this.violations = new Dictionary<string, IList<Violation>>();
        }

        public bool Empty
        {
            get
            {
                return this.violations.Count == 0;
            }
        }

        public IDictionary<string, IList<Violation>> Violations
        {
            get
            {
                return this.violations;
            }
        }

        public void AddViolationToFile(string fileName, Violation violation)
        {
            if (this.violations.ContainsKey(fileName))
            {
                IList<Violation> currentViolationList;

                if (this.violations.TryGetValue(fileName, out currentViolationList))
                {
                    currentViolationList.Add(violation);
                }
            }
            else
            {
                this.violations.Add(fileName, new List<Violation> { violation });
            }
        }

        public int GetTotalViolationsForFile(string fileName)
        {
            IList<Violation> violations;

            if (this.violations.TryGetValue(fileName, out violations))
            {
                return violations.Count;
            }

            return 0;
        }
    }
}

using System;

namespace CD_WithModifiedContact.Helpers
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ExecutionOrderAttribute : Attribute
    {
        public int Order { get; }

        public string FormulaName { get; }

        public ExecutionOrderAttribute(int order, string formulaName)
        {
            Order = order;
            FormulaName = formulaName;
        }
    }
}

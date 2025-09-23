using System;

namespace CD_WithModifiedContact.Helpers
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ExecutionOrderAttribute : Attribute
    {
        public int Order { get; }

        public ExecutionOrderAttribute(int order)
        {
            Order = order;
        }
    }
}

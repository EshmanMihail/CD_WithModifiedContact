using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

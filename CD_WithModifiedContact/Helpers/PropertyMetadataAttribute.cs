using System;

namespace CD_WithModifiedContact.Helpers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PropertyMetadataAttribute : Attribute
    {
        public string Symbol { get; set; }

        public PropertyMetadataAttribute(string symbol)
        {
            Symbol = symbol;
        }
    }
}

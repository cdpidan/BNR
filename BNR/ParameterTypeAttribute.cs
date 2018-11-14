using System;

namespace BNR
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ParameterTypeAttribute : Attribute
    {
        public ParameterTypeAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
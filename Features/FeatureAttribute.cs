using System;

namespace Features
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class FeatureAttribute : Attribute
    {
        public FeatureAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

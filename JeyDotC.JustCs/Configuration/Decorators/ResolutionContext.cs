using System;
using System.Reflection;

namespace JeyDotC.JustCs.Configuration.Decorators
{
    public struct ResolutionContext
    {
        public IServiceProvider ServiceProvider { get; init; }

        public PropertyInfo Property { get; init; }

        public InjectAttribute InjectInfo { get; init; }

        public Type ComponentType { get; init; }

        public void Deconstruct(out IServiceProvider serviceProvider, out PropertyInfo property)
        {
            serviceProvider = ServiceProvider;
            property = Property;
        }

        public void Deconstruct(out IServiceProvider serviceProvider, out PropertyInfo property, out InjectAttribute inject)
        {
            serviceProvider = ServiceProvider;
            property = Property;
            inject = InjectInfo;
        }

        public void Deconstruct(out IServiceProvider serviceProvider, out PropertyInfo property, out InjectAttribute inject, out Type componentType)
        {
            serviceProvider = ServiceProvider;
            property = Property;
            inject = InjectInfo;
            componentType = ComponentType;
        }
    }
}


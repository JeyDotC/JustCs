﻿using System;

namespace JeyDotC.JustCs.Configuration.Decorators
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InjectAttribute : Attribute
    {
        public bool Required { get; init; }

        public InjectAttribute(bool required = false)
        {
            Required = required;
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    
    internal sealed class AttributesDecoratorSet : ISet<IAttributesDecorator>
    {
        private sealed class ByTypeComparer : IEqualityComparer<IAttributesDecorator>
        {
            [ExcludeFromCodeCoverage]
            public bool Equals(IAttributesDecorator? x, IAttributesDecorator? y)
            {
                var xType = x?.GetType();
                var yType = y?.GetType();

                if (xType is null && yType is null)
                {
                    return true;
                }

                if (xType is null || yType is null)
                {
                    return false;
                }

                if(x is DelegateAttributesDecorator && y is DelegateAttributesDecorator)
                {
                    return x.Equals(y);
                }

                return xType == yType;
            }

            public int GetHashCode([DisallowNull] IAttributesDecorator obj)
                => obj is DelegateAttributesDecorator ? obj.GetHashCode() : obj.GetType().GetHashCode();
        }

        private readonly ISet<IAttributesDecorator> _implementation = new HashSet<IAttributesDecorator>(new ByTypeComparer());

        public int Count => _implementation.Count;

        [ExcludeFromCodeCoverage]
        public bool IsReadOnly => _implementation.IsReadOnly;

        public bool Add(IAttributesDecorator item)
        {
            if(item == null)
            {
                return false;
            }

            return _implementation.Add(item);
        }

        [ExcludeFromCodeCoverage]
        public void Clear() => _implementation.Clear();
        [ExcludeFromCodeCoverage]
        public bool Contains(IAttributesDecorator item) => _implementation.Contains(item);
        [ExcludeFromCodeCoverage]
        public void CopyTo(IAttributesDecorator[] array, int arrayIndex) => _implementation.CopyTo(array, arrayIndex);
        [ExcludeFromCodeCoverage]
        public void ExceptWith(IEnumerable<IAttributesDecorator> other) => _implementation.ExceptWith(other);
        [ExcludeFromCodeCoverage]
        public IEnumerator<IAttributesDecorator> GetEnumerator() => _implementation.GetEnumerator();
        [ExcludeFromCodeCoverage]
        public void IntersectWith(IEnumerable<IAttributesDecorator> other) => _implementation.IntersectWith(other);
        [ExcludeFromCodeCoverage]
        public bool IsProperSubsetOf(IEnumerable<IAttributesDecorator> other) => _implementation.IsProperSubsetOf(other);
        [ExcludeFromCodeCoverage]
        public bool IsProperSupersetOf(IEnumerable<IAttributesDecorator> other) => _implementation.IsProperSupersetOf(other);
        [ExcludeFromCodeCoverage]
        public bool IsSubsetOf(IEnumerable<IAttributesDecorator> other) => _implementation.IsSubsetOf(other);
        [ExcludeFromCodeCoverage]
        public bool IsSupersetOf(IEnumerable<IAttributesDecorator> other) => _implementation.IsSupersetOf(other);
        [ExcludeFromCodeCoverage]
        public bool Overlaps(IEnumerable<IAttributesDecorator> other) => _implementation.Overlaps(other);
        [ExcludeFromCodeCoverage]
        public bool Remove(IAttributesDecorator item) => _implementation.Remove(item);
        [ExcludeFromCodeCoverage]
        public bool SetEquals(IEnumerable<IAttributesDecorator> other) => _implementation.SetEquals(other);
        [ExcludeFromCodeCoverage]
        public void SymmetricExceptWith(IEnumerable<IAttributesDecorator> other) => _implementation.SymmetricExceptWith(other);
        [ExcludeFromCodeCoverage]
        public void UnionWith(IEnumerable<IAttributesDecorator> other) => _implementation.UnionWith(other);
        [ExcludeFromCodeCoverage]
        void ICollection<IAttributesDecorator>.Add(IAttributesDecorator item)
        {
            if(item == null)
            {
                return;
            }

            ((ICollection<IAttributesDecorator>)_implementation).Add(item);
        }
        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_implementation).GetEnumerator();
    }
}


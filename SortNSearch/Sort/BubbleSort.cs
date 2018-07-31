using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SortNSearch.Sort
{
    public static class BubbleSort
    {
        public static IList<TObject> BubbleSortBy<TObject, TMember>(
            this IList<TObject> collection, Expression<Func<TObject, TMember>> expression, bool ascending) where TMember : struct,
          IComparable,
          IComparable<TMember>,
          IConvertible,
          IEquatable<TMember>,
          IFormattable
        {
            var itemCount = collection.Count;

            var propertyName = PropertyManager.GetMemberName(expression.Body);
            var isComplete = false;
            while (!isComplete)
            {
                var swapped = false;
                for (var i = 1; i < itemCount; i++)
                {
                    var comparason = PropertyManager.GetMemberValue<TObject, TMember>(collection[i-1], propertyName).CompareTo(PropertyManager.GetMemberValue<TObject, TMember>(collection[i], propertyName));
                    if (ascending ? (comparason > 0) : (comparason < 0))
                    {
                        collection = collection.Swap(i -1, i);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    isComplete = true;
                }
            }
            return collection;
        }

    }
}

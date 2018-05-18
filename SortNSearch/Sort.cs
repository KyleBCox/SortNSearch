using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SortNSearch
{
    public static class Sort
    {
        public static IList<TObject> BubbleSortBy<TObject, TMember>(
            this IList<TObject> collection, Expression<Func<TObject, TMember>> expression, bool ascending) where TMember : struct,
          IComparable,
          IComparable<TMember>,
          IConvertible,
          IEquatable<TMember>,
          IFormattable
        {
            var itemCount = 0u;
            foreach (var item in collection)
            {
                itemCount++;
            }

            var propertyName = PropertyManager.GetMemberName(expression.Body);
            bool isComplete = false;
            while (!isComplete)
            {
                var swapped = false;
                for (var i = 1; i < itemCount; i++)
                {
                    var prevItem = collection[i - 1];
                    var item = collection[i];
                    var comparason = PropertyManager.GetMemberValue<TObject, TMember>(prevItem, propertyName).CompareTo(PropertyManager.GetMemberValue<TObject, TMember>(item, propertyName));
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
        private static IList<TObject> Swap<TObject>(this IList<TObject> collection, int index0, int index1)
        {
            var temp = collection[index0];
            collection[index0] = collection[index1];
            collection[index1] = temp;
            return collection;
        }
    }
}

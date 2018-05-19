using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace SortNSearch.Sort
{
    public static class SelectionSort
    {
        public static IList<TObject> SelectionSortBy<TObject, TMember>(
            this IList<TObject> collection, Expression<Func<TObject, TMember>> expression, bool ascending) where TMember : struct,
  IComparable,
  IComparable<TMember>,
  IConvertible,
  IEquatable<TMember>,
  IFormattable
        {
            var itemCount = collection.Count;
            var propertyName = PropertyManager.GetMemberName(expression.Body);

            for (var j = 0; j < itemCount; j++)
            {
                var iMin = j;
                for (var i = j+1; i < itemCount; i++)
                {
                    var comparason = PropertyManager.GetMemberValue<TObject, TMember>(collection[i], propertyName).CompareTo(PropertyManager.GetMemberValue<TObject, TMember>(collection[iMin], propertyName));

                    if (ascending ? (comparason > 0) : (comparason < 0))
                    {
                        iMin = i;
                    }
                }
                if (iMin != j)
                {
                    collection = collection.Swap(j, iMin);
                }
            }
            return collection;
        }
    }
}

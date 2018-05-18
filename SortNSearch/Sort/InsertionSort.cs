using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace SortNSearch.Sort
{
    public static class InsertionSort
    {
        public static IList<TObject> InsertionSortBy<TObject, TMember>(this IList<TObject> collection, Expression<Func<TObject, TMember>> expression, bool ascending) where TMember : struct,
          IComparable,
          IComparable<TMember>,
          IConvertible,
          IEquatable<TMember>,
          IFormattable
        {
            var propertyName = PropertyManager.GetMemberName(expression.Body);
            for (var i = 1; i < collection.Count; i++)
            {
                var j = i;
                var comparason = PropertyManager.GetMemberValue<TObject, TMember>(collection[j-1], propertyName).CompareTo(PropertyManager.GetMemberValue<TObject, TMember>(collection[j], propertyName));
                while (j > 0 && (ascending ? (comparason > 0) : (comparason < 0)))
                {
                    collection = collection.Swap(j - 1, j);
                    j--;
                    if (j > 0)
                    {
                        comparason = PropertyManager.GetMemberValue<TObject, TMember>(collection[j - 1], propertyName).CompareTo(PropertyManager.GetMemberValue<TObject, TMember>(collection[j], propertyName));
                    }
                }
            }
            return collection;
        }
    }
}

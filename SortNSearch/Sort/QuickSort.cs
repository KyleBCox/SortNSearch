using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using SortNSearch;

namespace SortNSearch.Sort
{
    public static class QuickSort
    {
        public static IList<TObject> QuickSortBy<TObject, TMember>(
           this IList<TObject> collection, Expression<Func<TObject, TMember>> expression, bool ascending) where TMember : struct,
         IComparable,
         IComparable<TMember>,
         IConvertible,
         IEquatable<TMember>,
         IFormattable
        {
            var propertyName = PropertyManager.GetMemberName(expression.Body);
            QuickSorter<TObject, TMember>(ref collection, 0, collection.Count - 1, propertyName, ascending);
            return collection;
        }
        internal static void QuickSorter<TObject, TMember>(ref IList<TObject> collection, int lo, int hi, string propertyName, bool ascending) where TMember : struct,
           IComparable,
           IComparable<TMember>,
           IConvertible,
           IEquatable<TMember>,
           IFormattable
        {
            if (lo < hi)
            {
                var p = Partition<TObject, TMember>(ref collection, lo, hi, propertyName, ascending);
                QuickSorter<TObject, TMember>(ref collection, lo, p - 1, propertyName, ascending);
                QuickSorter<TObject, TMember>(ref collection, p + 1, hi, propertyName, ascending);
            }

        }
        internal static int Partition<TObject, TMember>(ref IList<TObject> collection, int lo, int hi, string propertyName, bool ascending) where TMember : struct,
        IComparable,
     IComparable<TMember>,
     IConvertible,
     IEquatable<TMember>,
     IFormattable
        {
            var pivot = PropertyManager.GetMemberValue<TObject, TMember>(collection[hi], propertyName);
            var i = lo - 1;
            for (var j = lo; j <= hi - 1; j++)
            {
                var comparason = PropertyManager.GetMemberValue<TObject, TMember>(collection[j], propertyName).CompareTo(pivot);
                if (ascending ? comparason > 0 : comparason < 0)
                {
                    i++;
                    collection = collection.Swap(i, j);
                }
            }
            collection = collection.Swap(i + 1, hi);
            return i + 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SortNSearch.Sort
{
    public static class Common
    {
        internal static IList<TObject> Swap<TObject>(this IList<TObject> collection, int index0, int index1)
        {
            var temp = collection[index0];
            collection[index0] = collection[index1];
            collection[index1] = temp;
            return collection;
        }
    }
}

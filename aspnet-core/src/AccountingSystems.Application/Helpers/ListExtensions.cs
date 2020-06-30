using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingSystems.Helpers
{
    public static class ListExtensions
    {
        public static List<SelectListItem> ToSelectItemList<T>(this IEnumerable<T> collection, Func<T, string> nameGetter, Func<T, int> idGetter)
        {
            return collection.Select(m => new SelectListItem
            {
                Text = nameGetter(m),
                Value = idGetter(m).ToString()
            }).ToList();
        }
    }
}

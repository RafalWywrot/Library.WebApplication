using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApplication.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<TType, TKey>(this IEnumerable<TType> items,
             Func<TType, TKey> key,
             Func<TType, string> text)
        {
            return items.Select(item =>
                new SelectListItem
                {
                    Text = text(item),
                    Value = key(item).ToString()
                });
        }
    }
}
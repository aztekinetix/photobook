using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PhotoBook.HtmlHelpers
{
    public static class SecuredValueHtmlHelper
    {
        public static string SecuredHiddenField(this HtmlHelper htmlHelper, string name, object value)
        {
            var html = new StringBuilder();
            html.Append(htmlHelper.Hidden(name, value));
            html.Append(GetHashFieldHtml(htmlHelper, name, GetValueAsString(value)));
            return html.ToString();
        }

        public static string HashField(this HtmlHelper htmlHelper, string name, object value)
        {
            return GetHashFieldHtml(htmlHelper, name, GetValueAsString(value));
        }

        public static string MultipleFieldHashField(this HtmlHelper htmlHelper, string name, IEnumerable values)
        {
            var valueToHash = new StringBuilder();
            foreach (var v in values)
            {
                valueToHash.Append(v);
            }

            return HashField(htmlHelper, name, valueToHash);
        }

        private static string GetValueAsString(object value)
        {
            return Convert.ToString(value, CultureInfo.CurrentCulture);
        }

        private static string GetHashFieldHtml(HtmlHelper htmlHelper, string name, string value)
        {
            return htmlHelper.Hidden(SecuredValueFieldNameComputer.GetSecuredValueFieldName(name),
                                     SecuredValueHashComputer.GetHash(value));
        }
    }


}
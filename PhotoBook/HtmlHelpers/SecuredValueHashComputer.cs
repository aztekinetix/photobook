using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoBook.HtmlHelpers
{
    public static class SecuredValueHashComputer
    {
        public static string Secret { get; set; }
        public static IHashComputer HashComputer { get; set; }

        static SecuredValueHashComputer()
        {
            Secret = "zomg!";
            HashComputer = new SHA1HashComputer();
        }

        public static string GetHash(string value)
        {
            return HashComputer.GetBase64HashString(value, Secret);
        }
    }


}
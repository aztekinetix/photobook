using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoBook.Exceptions
{
    public class NonValidFileExtension : Exception
    {
        public NonValidFileExtension():base()
        {
            
        }

        public NonValidFileExtension(string message) : base(message)
        {

        }

        public NonValidFileExtension(string message , Exception innerException) : base(message, innerException)
        {

        }
    }
}
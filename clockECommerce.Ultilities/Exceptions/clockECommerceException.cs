using System;
using System.Collections.Generic;
using System.Text;

namespace clockECommerce.Ultilities.Exceptions
{
    public class clockECommerceException : Exception
    {
        public clockECommerceException()
        {

        }
        public clockECommerceException(string message)
            : base(message)
        {
        }

        public clockECommerceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

using clockECommerce.ViewModels.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace clockECommerce.ViewModels.Catalog.Products
{
    public class ReviewBrowserRequest
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}

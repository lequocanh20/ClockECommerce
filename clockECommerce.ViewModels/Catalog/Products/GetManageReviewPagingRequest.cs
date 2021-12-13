using clockECommerce.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace clockECommerce.ViewModels.Catalog.Products
{
    public class GetManageReviewPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public int? ProductId { get; set; }

        public string? SortOption { get; set; }
    }
}

using clockECommerce.ViewModels.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace clockECommerce.ViewModels.Sales
{
    public class UpdateOrderStatusViewModel
    {
        public int OrderId { get; set; }
        public OrderStatus status { get; set; }
    }
}

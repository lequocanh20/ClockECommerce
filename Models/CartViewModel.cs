﻿using clockECommerce.ViewModels.Sales;
using System.Collections.Generic;

namespace clockECommerce.WebApp.Models
{
    public class CartViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public int Promotion { get; set; }
        public string CouponCode { get; set; }
    }
}
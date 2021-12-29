﻿using System.Globalization;

namespace Web.Models
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string PictureUri { get; set; }

        public string PriceUsd => Price.ToString("c2", new CultureInfo("en-US"));
    }
}
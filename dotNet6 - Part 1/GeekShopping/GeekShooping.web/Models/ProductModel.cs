﻿using System.ComponentModel.DataAnnotations;

namespace GeekShopping.web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageURL { get; set; }
    }
}

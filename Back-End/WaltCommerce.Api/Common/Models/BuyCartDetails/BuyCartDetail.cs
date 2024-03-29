﻿using Common.Models.BuyCarts;
using Common.Models.Core;
using Common.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models.BuyCartDetails
{
    public class BuyCartDetail : BaseModel
    {
        public BuyCart BuyCart { get; set; }
        public int BuyCartId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [NotMapped]
        public float Total {
            get => Product.Price * Quantity; 
        }
    }
}

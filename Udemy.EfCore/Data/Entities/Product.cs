using System;
using System.Collections.Generic;

namespace Udemy.EfCore.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //navigation property
        public List<SaleHistory> SaleHistories { get; set; } //bir productın birden fazla satış geçmişi olabillir
        public ProductDetail ProductDetail { get; set; } //bir productın bir tane detaili olabilir
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }

        public List<ProductCategory> ProductCategories { get; set; } //bir product'ın birden fazla productkategoriye sahip olabilir.
    }
}

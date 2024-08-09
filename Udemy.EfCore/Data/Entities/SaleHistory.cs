namespace Udemy.EfCore.Data.Entities
{
    public class SaleHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //navigation property
        public Product Product { get; set; } //bir satış geçmişinin bir product'a ihtiyacı var.
        public int amount { get; set; }
    }
}

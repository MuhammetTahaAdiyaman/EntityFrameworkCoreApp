namespace Udemy.EfCore.Data.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } //bir product detailinin bir product'a ihtiyacı var
    }
}

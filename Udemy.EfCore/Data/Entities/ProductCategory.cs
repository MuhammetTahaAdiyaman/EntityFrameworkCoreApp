namespace Udemy.EfCore.Data.Entities
{
    public class ProductCategory
    {   //many to many için ara tablomuz bu tablo bir tane product bir tane category'e ihtiyacı var
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

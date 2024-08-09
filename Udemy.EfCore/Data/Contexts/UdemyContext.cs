using Microsoft.EntityFrameworkCore;
using Udemy.EfCore.Data.Entities;

namespace Udemy.EfCore.Data.Contexts
{
    public class UdemyContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=TAHA\\SQLEXPRESS; database=UdemyEfCore; integrated security=true");
        }

        //fluent api yazmamız için bir methodu override yapmamız gerekiyor
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //table per type için yapmamız gerekenler
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployees");
            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployees");



            //many to many için ara tablomuza iki tane 1:n ilişkisi kurmamız gerekecek
            //product tablosu için
            modelBuilder.Entity<Product>().HasMany(x=>x.ProductCategories).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            //category tablosu için
            modelBuilder.Entity<Category>().HasMany(x => x.ProductCategories).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            //bir de aynı kayıtların girilmemesi için productıd ve categoryıd p.k yapalım.
            modelBuilder.Entity<ProductCategory>().HasKey(x => new
            {
                x.ProductId, x.CategoryId
            });

            //one to one ilişki kurmak için yine iki tablo üzerinden gidebiliriz
            //product tablosu üzerinden 1:1 ilişki kuralım
            //not: 1:1 ilişkilerde foreign key olan yeri belirtmemiz gerekiyor.
            modelBuilder.Entity<Product>().HasOne(x => x.ProductDetail).WithOne(x => x.Product).HasForeignKey<ProductDetail>(x => x.ProductId);
            
            
            
            //One to Many ilişki kurmak için iki tablo üzerinden de gidebiliriz
            //ilk önce products tablosu üzerinden gidelim.
            modelBuilder.Entity<Product>().HasMany(x=>x.SaleHistories).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
            //şimdi saleshistory tablosu üzerinden gidelim.
            //modelBuilder.Entity<SaleHistory>().HasOne(x => x.Product).WithMany(x => x.SaleHistories).HasForeignKey(x => x.ProductId);

          //unique index oluşturmak için;
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique(); //artık aynı isimden iki ürün eklenmeye çalıştığında hata fırlatacaktır.

            
            //default değerler için;
            //modelBuilder.Entity<Product>().Property(x => x.Name).HasDefaultValueSql("'urun bilgisi girilmemis'");
            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");

            //ilgili tek kolonu primary key yapmak için
            //modelBuilder.Entity<Customer>().HasKey(x=>x.Number);
            //ilgili birden fazla kolonu primary key yapmak istersek yani tek primary key olacak ama iki kolon kapsamasını istiyoruz.
            modelBuilder.Entity<Customer>().HasKey(x => new
            {
                x.Number,
                x.Name
            });
            //modelBuilder.Entity<Category>().ToTable(name: "Categories", schema: "dbo");

            //Product tablosundaki kolonları fluent api ile istediğimiz şekilde ayarlayalım.
            modelBuilder.Entity<Product>().Property(x=>x.Name).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(x=>x.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Product>().Property(x=>x.Id).HasColumnName("product_id");

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnName("product_price");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 3);
            base.OnModelCreating(modelBuilder);
        }
    }
}

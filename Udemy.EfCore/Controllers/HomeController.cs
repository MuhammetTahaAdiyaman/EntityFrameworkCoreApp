using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Udemy.EfCore.Data.Contexts;
using Udemy.EfCore.Data.Entities;

namespace Udemy.EfCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {   //database'e Crud işlemlerini gerçekleştirmek için öncelikle 
            UdemyContext context = new UdemyContext();
            //şimdi eklenecek durumu bildirmek için bir kod yazalım. Bu kodu yazınca hemen eklenmiyor.
            //var entityEntries = context.Add(new Data.Entities.Product
            //{
            //    Name = "Telefon",
            //    Price = 3400
            //});
            ////şimdi burada id belirtmiyoruz belirtmesek bile o otomatik olarak uniqe ve otomatik artan olmasını sağlıyor.
            //şimdi eklenecek durumda olan kaydı database'e yollamak için şunu yazmamız gerekiyor. savechanges()

            //şimdi gelelim güncelleme işlemine
            //context.Products.Update(new Data.Entities.Product
            //{
            //    Id = 1,
            //    Name = "Bilgisayar",
            //});
            //veri tabanımıza baktığımızda belirtmediğimiz fiyat bilgisinin 0,00 olduğunu görüyoruz
            //bunun nedeni biz new product yani yeni bir nesne örneği aldığımız için oluyor
            //peki burada nasıl davranmalıyız ? öncelikle güncelleyeceğimiz veriyi çekmemiz daha sonra güncellememiz gerek hemen yapalım.
            /*var updatedProducts = context.Products.Find(1);*/ //find metodu bizden bir primary key yani id alanı bekliyor.
            //daha sonra bunun üzerinden güncellenecek alanı setleyelim.
            //updatedProducts.Price = 4000;
            //daha sonra bunu update metoduna verelimki state = modified yani güncellenecek duruma gelsin.
            //context.Products.Update(updatedProducts);
            //en sonda bu değişiklikleri veri tabanına yansıtmak için savechanges yapalım.
            //context.SaveChanges();

            //şimdi ise bir kaydı nasıl silebiliriz bir bakalım.
            //aynı update metodolijisinde olduğu gibi silmek istediğimiz kaydı çekelim daha sonra remove()metoduna verelim.
            //var deletedProduct = context.Products.FirstOrDefault(x => x.Id == 1); //productlar içinde idsi 1 olanlardan ilkini getir veya default == null olanı getir
            //remove metoduna verelim.
            //context.Products.Remove(deletedProduct);
            //state = delete olan kaydı veritabanına yansıtmak için;
            //context.SaveChanges();

            //default değerleri görebilmek için bir tane product nesnesi oluşturalım ve sadece price verelim
            //Product product = new Product() { Price = 4000};
            //context.Products.Add(product);
            //context.SaveChanges();

            //employee tablosu üzerinden parttime ve fulltime employee oluşturalım. Bu aslında solid prensiplerinden liskov subsitutiona giriyor
            context.Employees.Add(new PartTimeEmployee
            {
                 FirstName = "part",
                 LastName = "part",
                 DailyWage = 400

            });
            context.Employees.Add(new PartTimeEmployee
            {
                FirstName = "part2",
                LastName = "part2",
                DailyWage = 400

            });
            context.Employees.Add(new FullTimeEmployee
            {
                FirstName = "full",
                LastName = "full",
                HourlyWage = 600

            });

            context.SaveChanges();
            return View();
        }
    }
}

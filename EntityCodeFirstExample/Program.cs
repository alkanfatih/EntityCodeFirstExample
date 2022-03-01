using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EntityCodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectProduct();
            //SelectProductWhere();
            //AddProduct();
            //UpdateProduct();
            //DeleteProduct();
        }

        private static void SelectProduct()
        {
            ETradeContext eTradeContext = new ETradeContext();
            //Context sınıfımızı çağrıyoruz. 
            var list = eTradeContext.Products.ToList();
            //Context sınıfımızın product nesnesini ToList() methodu ile değişkene atıyoruz.
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("ID: " + list[i].ID + " Ürün Adı: " + list[i].Name + " Ürün Fiyat: " + list[i].UnitPrice + " Stok: " + list[i].StockAmount);
            }
            //Atanana listelerimizin içinde for ile dönerek verilere tek tek ulaşıyoruz.
            Console.ReadLine();
        }
        private static void SelectProductWhere()
        {
            ETradeContext eTradeContext = new ETradeContext();
            var list = eTradeContext.Products.Where(p => p.Name == "Laptop").ToList();
            //Product nesnemizi where methodu ile koşul sağlayabiliyoruz. Burada dikkat edilmesi gereken konu where koşulunu lambda kullanarak tanımlıyoruz. Lambda olarak atadığımız p simgesi listedeki her bir elemanı temsil eder.

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("ID: " + list[i].ID + " Ürün Adı: " + list[i].Name + " Ürün Fiyat: " + list[i].UnitPrice + " Stok: " + list[i].StockAmount);
            }
            Console.ReadLine();
        }
        private static void AddProduct()
        {
            ETradeContext eTradeContext = new ETradeContext();
            //Context sınıfımızı çağrıyoruz. 
            
            var product = new Product() { Name = "MacBook", UnitPrice = 9555.99M, StockAmount = 150 };
            //Produc sınfımızı kullanarak tabloya eklemek istediğimiz verilerimizi product adında bir değişkene atıyoruz.

            eTradeContext.Entry(product).State = EntityState.Added;
            //Oluşturduğumuz product değişkenini Entity nin Add özelliğini kullanarak Context sınıfmız üzerinde veritabanımıza eklenmesini sağlıyoruz.

            eTradeContext.SaveChanges();
            //Yapılan değişikliklerin kayıt edilmesini sağlıyoruz.

            Console.WriteLine("Ürün Eklendi");
            Console.ReadLine();
        }
        private static void UpdateProduct()
        {
            ETradeContext eTradeContext = new ETradeContext();
            var product = new Product() { ID = 1, Name = "UltraBook" };
            eTradeContext.Entry(product).State = EntityState.Modified;
            eTradeContext.SaveChanges();

            Console.WriteLine("Ürün Güncellendi");
            Console.ReadLine();
        }

        private static void DeleteProduct()
        {
            ETradeContext eTradeContext = new ETradeContext();
            var product = new Product() { ID = 3 };
            eTradeContext.Entry(product).State = EntityState.Deleted;
            eTradeContext.SaveChanges();

            Console.WriteLine("Ürün Silindi");
            Console.ReadLine();
        }
    }
}

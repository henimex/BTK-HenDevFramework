using System.Data.Entity.ModelConfiguration;
using HenDevFramework.Northwind.Entities.Concrete;

namespace HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //Veritabanında bulunan alanlar aynı ise buna gerek yok ama ilerleyen süreçlerde sorun olmaması için yapılmasında fayda var dedi engin hoca.
            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId).HasColumnName("ProductID");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
        }
    }
}

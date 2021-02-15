using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HenDevFramework.Core.DataAccess.EntityFramework;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;
using HenDevFramework.Northwind.Entities.DTOs;

namespace HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal: EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails(Expression<Func<Product, bool>> filter=null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in filter is null ? context.Products : context.Products.Where(filter)
                    join ct in context.Categories on p.CategoryId equals ct.CategoryId
                    select new ProductDetailDto
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = ct.CategoryName
                    };
                return result.ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.DataAccess;
using HenDevFramework.Northwind.Entities.Concrete;
using HenDevFramework.Northwind.Entities.DTOs;
using NHibernate.Criterion;

namespace HenDevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails(Expression<Func<Product, bool>> filter=null);
    }
}

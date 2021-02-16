using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.DataAccess.NHibernate;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;
using HenDevFramework.Northwind.Entities.DTOs;

namespace HenDevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nHibernateHelper;

        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetailDto> GetProductDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in filter is null ? session.Query<Product>() : session.Query<Product>().Where(filter)
                             join ct in session.Query<Category>() on p.CategoryId equals ct.CategoryId
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

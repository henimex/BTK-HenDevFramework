using HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using HenDevFramework.Northwind.DataAccess.Concrete.NHibernate;
using HenDevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HenDevFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTests
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.AreEqual(83,result.Count);
            //83 home 77 work
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(x=>x.ProductName.Contains("ab"));
            Assert.AreEqual(4,result.Count);
        }

        [TestMethod]
        public void Get_all_returns_all_categories()
        {
            NhCategoryDal categoryDal = new NhCategoryDal(new SqlServerHelper());
            var result = categoryDal.GetList();
            Assert.AreEqual(8,result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_categories()
        {
            NhCategoryDal categoryDal = new NhCategoryDal(new SqlServerHelper());
            var result = categoryDal.GetList(x=>x.CategoryName.Contains("s"));
            Assert.AreEqual(6,result.Count);
        }

        [TestMethod]
        public void Get_filtered_ProductDetailDto_with_params()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(x => x.CategoryId == 1);
            Assert.AreEqual(14, result.Count);
        }
    }
}

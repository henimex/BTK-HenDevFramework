using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using HenDevFramework.Northwind.DataAccess.Concrete;
using HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework;

namespace HenDevFramework.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();
            Assert.AreEqual(77,result.Count);
            //83 home 77 work
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(x=>x.ProductName.Contains("ab"));
            Assert.AreEqual(4,result.Count);
        }

        [TestMethod]
        public void Get_all_returns_all_categories()
        {
            EfCategoryDal categoryDal = new EfCategoryDal();
            var result = categoryDal.GetList();
            Assert.AreEqual(8,result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_categories()
        {
            EfCategoryDal categoryDal = new EfCategoryDal();
            var result = categoryDal.GetList(x=>x.CategoryName.Contains("s"));
            Assert.AreEqual(6,result.Count);
        }

        [TestMethod]
        public void Get_filtered_ProductDetailDto_with_params()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(x => x.CategoryId == 1);
            Assert.AreEqual(12, result.Count);
            //home 14 work 12
        }
    }
}

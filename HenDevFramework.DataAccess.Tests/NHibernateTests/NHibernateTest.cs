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
            Assert.AreEqual(77,result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(x=>x.ProductName.Contains("ab"));
            Assert.AreEqual(4,result.Count);
        }
    }
}

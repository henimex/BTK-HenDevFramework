using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentValidation;
using HenDevFramework.Northwind.Business.Concrete.Managers;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;
using Moq;

namespace HenDevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTest  
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}

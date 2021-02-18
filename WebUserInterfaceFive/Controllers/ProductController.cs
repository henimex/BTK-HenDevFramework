using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenDevFramework.Northwind.Business.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;
using WebUserInterfaceFive.Models;

namespace WebUserInterfaceFive.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(
                new Product {CategoryId = 1, ProductName = "Gsm", QuantityPerUnit = "1", UnitPrice = 30});
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(
                new Product {CategoryId = 1, ProductName = "TransactionTest1", QuantityPerUnit = "1", UnitPrice = 21},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "TransactionTest2", QuantityPerUnit = "1", UnitPrice = 5});
            return "Transaction Operation Done";
        }
    }
}
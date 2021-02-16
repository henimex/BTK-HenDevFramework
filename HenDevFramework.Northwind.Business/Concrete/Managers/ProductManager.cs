using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HenDevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using HenDevFramework.Northwind.Business.Abstract;
using HenDevFramework.Northwind.Business.ValidationRules.FluentValidation;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;
using HenDevFramework.Core.Aspects.Postsharp;
using HenDevFramework.Core.Aspects.Postsharp.TransactionAspects;
using HenDevFramework.Core.Aspects.Postsharp.ValidationAspects;

namespace HenDevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        //Ornek Operasyon
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //BusinessCodes
            _productDal.Update(product2);

            /*
             * Burda Coklu işlemde birden fazla islemi denedigimizde eger operasyonlardan bir tanesi fail olursa onceki yapılan islemlerin geri alınmasını saglamak icin yapı olusuturluyor.
             * Banka transferi yapıldı gondericen para dustu
             * fakat bir hatadan dolayı karsı tarafa bu gecmediginde ilk kullanıcının hesabına paranın geri aktarılmasını saglayan yapı.
             * kısaca bu bir try catch işlemine tabi tutuluyor exception fırlattıgında ise islemlerin tamamını dispose ediyor.
             * Aspects > PostSharp > TransactionalScopeAspect >>
             */
        }
    }
}

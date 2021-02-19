using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.DataAccess;
using HenDevFramework.Core.DataAccess.EntityFramework;
using HenDevFramework.Core.DataAccess.NHibernate;
using HenDevFramework.Northwind.Business.Abstract;
using HenDevFramework.Northwind.Business.Concrete.Managers;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using HenDevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace HenDevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQuaryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();

            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}

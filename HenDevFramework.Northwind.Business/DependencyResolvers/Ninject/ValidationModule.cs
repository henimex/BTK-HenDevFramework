using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HenDevFramework.Northwind.Business.ValidationRules.FluentValidation;
using HenDevFramework.Northwind.Entities.Concrete;
using Ninject.Modules;

namespace HenDevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}

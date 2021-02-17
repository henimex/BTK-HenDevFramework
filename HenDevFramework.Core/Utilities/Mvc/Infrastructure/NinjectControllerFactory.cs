using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;


namespace HenDevFramework.Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        //ulen ne ugrastım seninle
        //PM> Install-Package Microsoft.AspNet.Mvc -Version 5.2.3

        private IKernel _kernel;

        public NinjectControllerFactory(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}

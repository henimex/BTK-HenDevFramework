using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.DataAccess.NHibernate;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;

namespace HenDevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>,ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }
    }
}

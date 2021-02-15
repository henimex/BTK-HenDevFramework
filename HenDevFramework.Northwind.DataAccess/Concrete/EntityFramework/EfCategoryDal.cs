using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.DataAccess.EntityFramework;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;

namespace HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}

using HenDevFramework.Core.DataAccess.EntityFramework;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;

namespace HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal: EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Core.DataAccess.EntityFramework;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;
using HenDevFramework.Northwind.Entities.DTOs;

namespace HenDevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleDto> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                    join r in context.Roles
                        on ur.UserId equals user.Id
                    where ur.UserId == user.Id
                    select new UserRoleDto {RoleName = r.Name};
                return result.ToList();
            }
        }
    }
}

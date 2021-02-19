using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Northwind.Entities.Concrete;
using HenDevFramework.Northwind.Entities.DTOs;

namespace HenDevFramework.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameAndPassword(string username, string password);
        List<UserRoleDto> GetUserRoles(User user);
    }
}

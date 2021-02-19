using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenDevFramework.Northwind.Business.Abstract;
using HenDevFramework.Northwind.DataAccess.Abstract;
using HenDevFramework.Northwind.Entities.Concrete;
using HenDevFramework.Northwind.Entities.DTOs;

namespace HenDevFramework.Northwind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return _userDal.Get(u => u.UserName == username && u.Password == password);
        }

        public List<UserRoleDto> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenDevFramework.Core.CrossCuttingConcerns.Security.Web;
using HenDevFramework.Northwind.Business.Abstract;

namespace WebUserInterfaceFive.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string username,string password)
        {
            var user = _userService.GetByUserNameAndPassword(username,password);

            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                    new[] { "Admin" }, // _userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray(),
                false,
                user.FirstName,
                user.LastName);
                return "User is Authorized";
            }

            return "User is not Authorized";
        }

        public string LoginTest()
        {
            AuthenticationHelper.CreateAuthCookie(new Guid(),
                "henimex",
                "henimex@gmail.com",
                DateTime.Now.AddDays(15),
                new[]
                {"Admin"},
                false,
                "Ferhat",
                "Oygur");
            return "User is Authorized";
        }
    }
}
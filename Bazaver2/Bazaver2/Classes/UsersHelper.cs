using Bazaver2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Bazaver2.Classes
{
    public class UsersHelper : IDisposable
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static Bazaver2DbContext db = new Bazaver2DbContext();

        public static void CheckRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            // Check to see if Role Exists, if not create it
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var email = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassWord"];
            var userASP = userManager.FindByName(email);
            if (userASP == null)
            {
                CreateUserASP(email, "Admin", password);
                return;
            }

            userManager.AddToRole(userASP.Id, "Admin");
        }

        internal static void CheckMayorista()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var email = WebConfigurationManager.AppSettings["MayUser"];
            var password = WebConfigurationManager.AppSettings["MayPassword"];
            var userASP = userManager.FindByName(email);
            if (userASP == null)
            {
                CreateUserASP(email, "Mayorista", password);
                return;
            }

            userManager.AddToRole(userASP.Id, "Mayorista");
        }

        public static void CreateUserASP(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                userASP = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                };
                userManager.Create(userASP, email);
                userManager.AddToRole(userASP.Id, roleName);

            }
        }

        public static void CreateUserASP(string email, string roleName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, roleName);
        }

        //public static async Task PasswordRecovery(string email)
        //{
           
        //}

        public void Dispose()
        {
            userContext.Dispose();
            db.Dispose();
        }

        public static bool UpdateUserName(string currentUserName, string newUserName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userAsp = userManager.FindByEmail(currentUserName);
            if (userAsp == null)
            {
                return false;
            }
            userAsp.UserName = newUserName;
            userAsp.Email = newUserName;
            var response = userManager.Update(userAsp);
            return response.Succeeded;

        }

        public static bool DeleteUser(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return false;
            }

            userManager.RemoveFromRole(userASP.Id, roleName);
            return true;
        }



    }
}

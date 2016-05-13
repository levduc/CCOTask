namespace CCOTask.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CCOTask.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //true ?
        }

        protected override void Seed(CCOTask.Models.ApplicationDbContext context)
        {
            //Adding some default user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            //Adding 3 roles
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" }, new IdentityRole { Name = "Student" }, new IdentityRole { Name = "Conselor" });
            context.SaveChanges();
            //
            if (!context.Users.Any(t=>t.UserName == "diamondduck@purdue.edu"))
            {
                var admin = new ApplicationUser { UserName = "diamondduck@purdue.edu", Email = "diamondduck@purdue.edu" };
                userManager.Create(admin, "Adm1npassword");
                userManager.AddToRole(admin.Id, "Admin");
            }

            if (!context.Users.Any(t => t.UserName == "diamonddog@purdue.edu"))
            {
                var conselor = new ApplicationUser { UserName = "diamonddog@purdue.edu", Email = "diamonddog@purdue.edu" };
                userManager.Create(conselor, "Consel0rpassword");
                userManager.AddToRole(conselor.Id, "Conselor");
            }

            if (!context.Users.Any(t => t.UserName == "diamonddeer@purdue.edu"))
            {
                var student = new ApplicationUser { UserName = "diamonddeer@purdue.edu", Email = "diamonddeer@purdue.edu" };
                userManager.Create(student, "Stud3ntpassword");
                userManager.AddToRole(student.Id, "Student");
            }
        }
    }
}

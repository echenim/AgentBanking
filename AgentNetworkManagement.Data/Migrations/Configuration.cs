namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AgentNetworkManagement.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AgentNetworkManagement.Data.ApplicationDbContext context)
        {


            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            //const string name = "admin@example.com";
            //const string password = "Admin@123456";
            //const string roleName = "Admin";

            ////Create Role Admin if it does not exist
            //var role = roleManager.FindByName(roleName);
            //if (role == null)
            //{
            //    role = new ApplicationRole(roleName);
            //    var roleresult = roleManager.Create(role);
            //}

            //var user = userManager.FindByName(name);
            //if (user == null)
            //{
            //    user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
            //    var result = userManager.Create(user, password);
            //    result = userManager.SetLockoutEnabled(user.Id, false);

            //}

            //var groupManager = new ApplicationGroupManager();
            //var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

            //groupManager.CreateGroup(newGroup);
            //groupManager.SetUserGroups(user.Id, new string[] { newGroup.Id });
            //groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });

            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////
        }
    }
}

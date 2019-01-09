using System.Data.Entity;
using AgentNetworkManager.Domain.Models;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Base;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using Echenim.Nine.Util.Audit;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AgentNetworkManagement.Data
{
    public class ApplicationDbContext
         : IdentityDbContext<ApplicationUser, ApplicationRole,
             string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("GoBigContext")
        {
        }

        static ApplicationDbContext()
        {
            //  Database.SetInitializer<ApplicationDbContext>(new RetailPlatform.Domain.PermissionAndAuthorization.Base.ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Add the ApplicationGroups property:
        public virtual IDbSet<ApplicationGroup> ApplicationGroups { get; set; }

        #region table

        public DbSet<Person> Persons { get; set; }

        public DbSet<National> National { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Area> Area { get; set; }

        public DbSet<Zone> Zone { get; set; }

        public DbSet<Cluster> Clusters { get; set; }

        public DbSet<Fund> Funds { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDesciptions> TransactionDesciptionses { get; set; }

        public DbSet<PersonAndFunctionalArea> PersonFunctionArea { get; set; }

        public DbSet<UserPositionHeldInOrganogramm> UserPositionHeld { get; set; }
        public DbSet<PlatformManagingRule> PlatformManagingRules { get; set; }

        public DbSet<Fee> Fees { get; set; }

        public DbSet<SystemAudit> SystemAudits { get; set; }
        public DbSet<SystemExceptionMarker> SystemExceptions { get; set; }

        public DbSet<CustomerBankAccountOpening> CustomerBankAccountOpening { get; set; }
        public DbSet<CustomerBankCardInformation> CustomerBankCardInformation { get; set; }

        public DbSet<CustomerBankAccountOpningAddress> CustomerBankAccountOpningAddresses { get; set; }
        public DbSet<CustomerNextOfKinInfo> CustomerNextOfKinInfo { get; set; }

        public DbSet<SpatialTransactionScheme> SpatialTransactional { get; set; }
     //  public DbSet<TransactionalSpace> SpatialTransactional { get; set; }

        public DbSet<SpatialNonTransactionScheme> SpatialNonTransactional { get; set; }

        public DbSet<AssignUsersToTheirAgentNetwork> UsersToTheirAgentNetworks { get; set; }

        #endregion

        #region service models


        public DbSet<Banks> Bankses { get; set; }
        public DbSet<TelComms> TelComs { get; set; }
        public DbSet<BillsPayment> Billers { get; set; }
        public DbSet<RevenueCollections> RevenueCollection { get; set; }

        #endregion


        // Override OnModelsCreating:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
                .WithRequired().HasForeignKey<string>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
            modelBuilder.Entity<ApplicationUserGroup>()
                .HasKey((ApplicationUserGroup r) =>
                    new
                    {
                        ApplicationUserId = r.ApplicationUserId,
                        ApplicationGroupId = r.ApplicationGroupId
                    }).ToTable("ApplicationUserGroups");

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
                .WithRequired().HasForeignKey<string>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
            modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) =>
                new
                {
                    ApplicationRoleId = gr.ApplicationRoleId,
                    ApplicationGroupId = gr.ApplicationGroupId
                }).ToTable("ApplicationGroupRoles");

        }
    }
}

namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Owner = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationGroupRoles",
                c => new
                    {
                        ApplicationRoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationGroupId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationRoleId, t.ApplicationGroupId })
                .ForeignKey("dbo.ApplicationGroups", t => t.ApplicationGroupId, cascadeDelete: true)
                .Index(t => t.ApplicationGroupId);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ApplicationGroupId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.ApplicationGroupId })
                .ForeignKey("dbo.ApplicationGroups", t => t.ApplicationGroupId, cascadeDelete: true)
                .Index(t => t.ApplicationGroupId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StateId = c.String(maxLength: 128),
                        AreaName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RegionId = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NationalId = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nationals", t => t.NationalId)
                .Index(t => t.NationalId);
            
            CreateTable(
                "dbo.Nationals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ProcessKind = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlatformManagingRules", t => t.ProcessKind)
                .Index(t => t.ProcessKind);
            
            CreateTable(
                "dbo.PlatformManagingRules",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankName = c.String(),
                        BankCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillsPayments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Kind = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clusters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ZoneId = c.String(maxLength: 128),
                        ClusterName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AreaId = c.String(maxLength: 128),
                        ZoneName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.CustomerBankAccountOpenings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        OtherName = c.String(maxLength: 50),
                        Sex = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerBankAccountOpningAddresses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        BirthPlace = c.String(nullable: false, maxLength: 30),
                        Addresss = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerBankAccountOpenings", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerBankCardInformations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        CardSerialNumber = c.String(nullable: false, maxLength: 25),
                        ProductName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerBankAccountOpenings", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerNextOfKinInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false),
                        Addresss = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerBankAccountOpenings", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FeeName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AgentId = c.String(maxLength: 128),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        Manager = c.String(nullable: false),
                        AvailableOrNot = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.AgentId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MidleName = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Gender = c.String(nullable: false, maxLength: 6),
                        ContactAddress = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpatialSchemes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Agent = c.String(nullable: false, maxLength: 128),
                        Partition = c.String(nullable: false, maxLength: 50),
                        Transaction = c.String(nullable: false, maxLength: 50),
                        Latitude = c.String(nullable: false, maxLength: 15),
                        Longitude = c.String(nullable: false, maxLength: 15),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Agent, cascadeDelete: true)
                .Index(t => t.Agent);
            
            CreateTable(
                "dbo.PersonAndFunctionalAreas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersoNameId = c.String(nullable: false),
                        WorkAreaId = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RevenueCollections",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Kind = c.String(nullable: false, maxLength: 10),
                        Preceed = c.Long(nullable: false),
                        Description = c.String(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SystemAudits",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Originator = c.String(nullable: false, maxLength: 100),
                        Reason = c.String(nullable: false, maxLength: 400),
                        Ranking = c.String(nullable: false, maxLength: 10),
                        DataKey = c.String(maxLength: 50),
                        Message = c.String(),
                        Exceptions = c.String(),
                        Stamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemExceptionMarkers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Originator = c.String(nullable: false, maxLength: 100),
                        Reason = c.String(nullable: false, maxLength: 400),
                        Ranking = c.String(nullable: false, maxLength: 10),
                        Message = c.String(),
                        Stamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TelComms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionDesciptions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TransactionId = c.String(maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 800),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transactions", t => t.TransactionId)
                .Index(t => t.TransactionId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonId = c.String(maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 400),
                        PreviousBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitedAount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.UserPositionHeldInOrganogramms",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        OrggrammId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.OrggrammId })
                .Index(t => t.UserId, unique: true, name: "IX_AspPerson")
                .Index(t => t.OrggrammId, name: "IX_Organogram");
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonId = c.String(maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AssignUsersToTheirAgentNetworks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        NetworkId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Nationals", t => t.NetworkId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NetworkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignUsersToTheirAgentNetworks", "NetworkId", "dbo.Nationals");
            DropForeignKey("dbo.AssignUsersToTheirAgentNetworks", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PersonId", "dbo.People");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TransactionDesciptions", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "PersonId", "dbo.People");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SpatialSchemes", "Agent", "dbo.People");
            DropForeignKey("dbo.Funds", "AgentId", "dbo.People");
            DropForeignKey("dbo.CustomerNextOfKinInfoes", "CustomerId", "dbo.CustomerBankAccountOpenings");
            DropForeignKey("dbo.CustomerBankCardInformations", "CustomerId", "dbo.CustomerBankAccountOpenings");
            DropForeignKey("dbo.CustomerBankAccountOpningAddresses", "CustomerId", "dbo.CustomerBankAccountOpenings");
            DropForeignKey("dbo.Clusters", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Zones", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Areas", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Regions", "NationalId", "dbo.Nationals");
            DropForeignKey("dbo.Nationals", "ProcessKind", "dbo.PlatformManagingRules");
            DropForeignKey("dbo.ApplicationUserGroups", "ApplicationGroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationGroupRoles", "ApplicationGroupId", "dbo.ApplicationGroups");
            DropIndex("dbo.AssignUsersToTheirAgentNetworks", new[] { "NetworkId" });
            DropIndex("dbo.AssignUsersToTheirAgentNetworks", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "PersonId" });
            DropIndex("dbo.UserPositionHeldInOrganogramms", "IX_Organogram");
            DropIndex("dbo.UserPositionHeldInOrganogramms", "IX_AspPerson");
            DropIndex("dbo.Transactions", new[] { "PersonId" });
            DropIndex("dbo.TransactionDesciptions", new[] { "TransactionId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SpatialSchemes", new[] { "Agent" });
            DropIndex("dbo.Funds", new[] { "AgentId" });
            DropIndex("dbo.CustomerNextOfKinInfoes", new[] { "CustomerId" });
            DropIndex("dbo.CustomerBankCardInformations", new[] { "CustomerId" });
            DropIndex("dbo.CustomerBankAccountOpningAddresses", new[] { "CustomerId" });
            DropIndex("dbo.Zones", new[] { "AreaId" });
            DropIndex("dbo.Clusters", new[] { "ZoneId" });
            DropIndex("dbo.Nationals", new[] { "ProcessKind" });
            DropIndex("dbo.Regions", new[] { "NationalId" });
            DropIndex("dbo.States", new[] { "RegionId" });
            DropIndex("dbo.Areas", new[] { "StateId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "ApplicationGroupId" });
            DropIndex("dbo.ApplicationGroupRoles", new[] { "ApplicationGroupId" });
            DropTable("dbo.AssignUsersToTheirAgentNetworks");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserPositionHeldInOrganogramms");
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionDesciptions");
            DropTable("dbo.TelComms");
            DropTable("dbo.SystemExceptionMarkers");
            DropTable("dbo.SystemAudits");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RevenueCollections");
            DropTable("dbo.PersonAndFunctionalAreas");
            DropTable("dbo.SpatialSchemes");
            DropTable("dbo.People");
            DropTable("dbo.Funds");
            DropTable("dbo.Fees");
            DropTable("dbo.CustomerNextOfKinInfoes");
            DropTable("dbo.CustomerBankCardInformations");
            DropTable("dbo.CustomerBankAccountOpningAddresses");
            DropTable("dbo.CustomerBankAccountOpenings");
            DropTable("dbo.Zones");
            DropTable("dbo.Clusters");
            DropTable("dbo.BillsPayments");
            DropTable("dbo.Banks");
            DropTable("dbo.PlatformManagingRules");
            DropTable("dbo.Nationals");
            DropTable("dbo.Regions");
            DropTable("dbo.States");
            DropTable("dbo.Areas");
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.ApplicationGroupRoles");
            DropTable("dbo.ApplicationGroups");
        }
    }
}

namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SpatialSchemes", newName: "SpatialNonTransactionSchemes");
            CreateTable(
                "dbo.SpatialTransactionSchemes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Agent = c.String(nullable: false, maxLength: 128),
                        Partition = c.String(nullable: false, maxLength: 50),
                        TransactionId = c.String(),
                        Transaction = c.String(nullable: false, maxLength: 50),
                        Latitude = c.String(nullable: false, maxLength: 15),
                        Longitude = c.String(nullable: false, maxLength: 15),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Agent);
            
            DropColumn("dbo.SpatialNonTransactionSchemes", "TransactionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpatialNonTransactionSchemes", "TransactionId", c => c.String());
            DropIndex("dbo.SpatialTransactionSchemes", new[] { "Agent" });
            DropTable("dbo.SpatialTransactionSchemes");
            RenameTable(name: "dbo.SpatialNonTransactionSchemes", newName: "SpatialSchemes");
        }
    }
}

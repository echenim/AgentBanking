namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpatialTransactionSchemes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AgentId = c.String(nullable: false, maxLength: 128),
                        Partition = c.String(nullable: false, maxLength: 50),
                        TransactionId = c.String(nullable: false, maxLength: 50),
                        Transaction = c.String(nullable: false, maxLength: 50),
                        Latitude = c.String(nullable: false, maxLength: 15),
                        Longitude = c.String(nullable: false, maxLength: 15),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpatialTransactionSchemes", "AgentId", "dbo.People");
            DropIndex("dbo.SpatialTransactionSchemes", new[] { "AgentId" });
            DropTable("dbo.SpatialTransactionSchemes");
        }
    }
}

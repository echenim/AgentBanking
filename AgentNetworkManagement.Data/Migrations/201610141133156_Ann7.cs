namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpatialNonTransactionSchemes",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpatialNonTransactionSchemes", "Agent", "dbo.People");
            DropIndex("dbo.SpatialNonTransactionSchemes", new[] { "Agent" });
            DropTable("dbo.SpatialNonTransactionSchemes");
        }
    }
}

namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpatialNonTransactionSchemes", "Agent", "dbo.People");
            DropIndex("dbo.SpatialNonTransactionSchemes", new[] { "Agent" });
            DropTable("dbo.SpatialNonTransactionSchemes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SpatialNonTransactionSchemes", "Agent");
            AddForeignKey("dbo.SpatialNonTransactionSchemes", "Agent", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}

namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionalSpaces",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Agent = c.String(nullable: false, maxLength: 128),
                        Partition = c.String(nullable: false, maxLength: 50),
                        TransactionId = c.String(nullable: false, maxLength: 50),
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
            DropForeignKey("dbo.TransactionalSpaces", "Agent", "dbo.People");
            DropIndex("dbo.TransactionalSpaces", new[] { "Agent" });
            DropTable("dbo.TransactionalSpaces");
        }
    }
}

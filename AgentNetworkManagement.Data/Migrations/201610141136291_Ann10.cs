namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionalSpaces", "Agent", "dbo.People");
            DropIndex("dbo.TransactionalSpaces", new[] { "Agent" });
            DropTable("dbo.TransactionalSpaces");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TransactionalSpaces", "Agent");
            AddForeignKey("dbo.TransactionalSpaces", "Agent", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}

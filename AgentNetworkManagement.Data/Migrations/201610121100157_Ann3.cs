namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SpatialTransactionSchemes", "TransactionId", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpatialTransactionSchemes", "TransactionId", c => c.String());
        }
    }
}

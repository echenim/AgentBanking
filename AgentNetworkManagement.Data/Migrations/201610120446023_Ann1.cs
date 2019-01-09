namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpatialSchemes", "TransactionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpatialSchemes", "TransactionId");
        }
    }
}

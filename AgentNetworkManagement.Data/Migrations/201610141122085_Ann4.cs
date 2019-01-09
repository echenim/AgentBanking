namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SpatialTransactionSchemes", name: "Agent", newName: "AgentId");
            RenameIndex(table: "dbo.SpatialTransactionSchemes", name: "IX_Agent", newName: "IX_AgentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SpatialTransactionSchemes", name: "IX_AgentId", newName: "IX_Agent");
            RenameColumn(table: "dbo.SpatialTransactionSchemes", name: "AgentId", newName: "Agent");
        }
    }
}

namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SpatialTransactionSchemes", newName: "TransactionalSpaces");
            RenameColumn(table: "dbo.TransactionalSpaces", name: "AgentId", newName: "Agent");
            RenameIndex(table: "dbo.TransactionalSpaces", name: "IX_AgentId", newName: "IX_Agent");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TransactionalSpaces", name: "IX_Agent", newName: "IX_AgentId");
            RenameColumn(table: "dbo.TransactionalSpaces", name: "Agent", newName: "AgentId");
            RenameTable(name: "dbo.TransactionalSpaces", newName: "SpatialTransactionSchemes");
        }
    }
}

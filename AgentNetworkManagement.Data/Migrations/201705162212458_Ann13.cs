namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerBankAccountOpenings", "Dob", c => c.String(nullable: false, maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerBankAccountOpenings", "Dob", c => c.DateTime(nullable: false));
        }
    }
}

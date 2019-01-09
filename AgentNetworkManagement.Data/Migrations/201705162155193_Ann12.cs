namespace AgentNetworkManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Ann12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerBankCardInformations", "AccountNumber", c => c.String(nullable: false, maxLength: 12));
            CreateIndex("dbo.CustomerBankCardInformations", "AccountNumber", unique: true, name: "xi_account_number");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CustomerBankCardInformations", "xi_account_number");
            DropColumn("dbo.CustomerBankCardInformations", "AccountNumber");
        }
    }
}

namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            DropTable("MembershipTypes");
        }
        
        public override void Down()
        {
        }
    }
}

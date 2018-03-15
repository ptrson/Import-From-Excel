namespace Import_From_Excel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "StreetName", c => c.String(maxLength: 300));
            AlterColumn("dbo.Addresses", "StreetNumber", c => c.String(maxLength: 300));
            AlterColumn("dbo.Addresses", "PostCode", c => c.String(maxLength: 300));
            AlterColumn("dbo.Addresses", "PostOfficeCity", c => c.String(maxLength: 300));
            AlterColumn("dbo.Addresses", "CorrespondenceStreetName", c => c.String(maxLength: 300));
            AlterColumn("dbo.Addresses", "CorrespondenceStreetnumber", c => c.String(maxLength: 300));
            AlterColumn("dbo.Addresses", "CorrespondencePostCode", c => c.String(maxLength: 300));
            AlterColumn("dbo.Addresses", "CorrespondencePostOfficeCity", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "CorrespondencePostOfficeCity", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Addresses", "CorrespondencePostCode", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Addresses", "CorrespondenceStreetnumber", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Addresses", "CorrespondenceStreetName", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Addresses", "PostOfficeCity", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Addresses", "PostCode", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Addresses", "StreetNumber", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Addresses", "StreetName", c => c.String(nullable: false, maxLength: 300));
        }
    }
}

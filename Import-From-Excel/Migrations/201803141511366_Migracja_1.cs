namespace Import_From_Excel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(nullable: false, maxLength: 300),
                        StreetNumber = c.String(nullable: false, maxLength: 300),
                        FlatNumber = c.String(maxLength: 300),
                        PostCode = c.String(nullable: false, maxLength: 300),
                        PostOfficeCity = c.String(nullable: false, maxLength: 300),
                        CorrespondenceStreetName = c.String(nullable: false, maxLength: 300),
                        CorrespondenceStreetnumber = c.String(nullable: false, maxLength: 300),
                        CorrespondenceFlatNumber = c.String(maxLength: 300),
                        CorrespondencePostCode = c.String(nullable: false, maxLength: 300),
                        CorrespondencePostOfficeCity = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 300),
                        SecondName = c.String(maxLength: 300),
                        Surname = c.String(nullable: false, maxLength: 300),
                        NationalIdentificationNumber = c.String(nullable: false, maxLength: 300),
                        PhoneNumber = c.String(nullable: false, maxLength: 300),
                        PhoneNumber2 = c.String(nullable: false, maxLength: 300),
                        AddressId = c.Int(nullable: false),
                        FinancialState_FinancialStateId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.FinancialStates", t => t.FinancialState_FinancialStateId)
                .Index(t => t.AddressId)
                .Index(t => t.FinancialState_FinancialStateId);
            
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        AgreementId = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 3000),
                        PersonId = c.Int(nullable: false),
                        FinancialStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgreementId)
                .ForeignKey("dbo.FinancialStates", t => t.FinancialStateId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.FinancialStateId);
            
            CreateTable(
                "dbo.FinancialStates",
                c => new
                    {
                        FinancialStateId = c.Int(nullable: false, identity: true),
                        OutstandingLiabilites = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Interests = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PenaltyInterests = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fees = c.Decimal(precision: 18, scale: 2),
                        CourtFees = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RepresentationCourtFees = c.Decimal(precision: 18, scale: 2),
                        VindicationCosts = c.Decimal(precision: 18, scale: 2),
                        RepresentationVindicationCosts = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FinancialStateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agreements", "PersonId", "dbo.People");
            DropForeignKey("dbo.Agreements", "FinancialStateId", "dbo.FinancialStates");
            DropForeignKey("dbo.People", "FinancialState_FinancialStateId", "dbo.FinancialStates");
            DropForeignKey("dbo.People", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Agreements", new[] { "FinancialStateId" });
            DropIndex("dbo.Agreements", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "FinancialState_FinancialStateId" });
            DropIndex("dbo.People", new[] { "AddressId" });
            DropTable("dbo.FinancialStates");
            DropTable("dbo.Agreements");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}

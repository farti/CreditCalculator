namespace CreditCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountOfCredit = c.Double(nullable: false),
                        InterestRatePerYear = c.Double(nullable: false),
                        TermInMonths = c.Double(nullable: false),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Installment = c.Double(nullable: false),
                        MonthlyPrincipal = c.Double(nullable: false),
                        MonthlyInterest = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TotalPrincipal = c.Double(nullable: false),
                        TotalInterest = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credits", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Credits", new[] { "PaymentId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Credits");
        }
    }
}

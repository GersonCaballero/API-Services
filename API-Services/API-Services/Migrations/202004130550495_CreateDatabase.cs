namespace API_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CertificatedImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinalUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Location = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                        Department = c.String(),
                        Municipality = c.String(),
                        LocationGPS = c.String(),
                        CellphoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IdServiceProviderUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviderUsers", t => t.IdServiceProviderUser, cascadeDelete: true)
                .Index(t => t.IdServiceProviderUser);
            
            CreateTable(
                "dbo.ServiceProviderUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                        Birthdate = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                        Department = c.String(),
                        Municipality = c.String(),
                        LocationGPS = c.String(),
                        CellphoneNumber = c.String(),
                        qualification = c.Int(nullable: false),
                        IdTypeServices = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeServices", t => t.IdTypeServices, cascadeDelete: true)
                .Index(t => t.IdTypeServices);
            
            CreateTable(
                "dbo.TypeServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        IdServiceProviderUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviderUsers", t => t.IdServiceProviderUser, cascadeDelete: true)
                .Index(t => t.IdServiceProviderUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "IdServiceProviderUser", "dbo.ServiceProviderUsers");
            DropForeignKey("dbo.PaymentTypes", "IdServiceProviderUser", "dbo.ServiceProviderUsers");
            DropForeignKey("dbo.ServiceProviderUsers", "IdTypeServices", "dbo.TypeServices");
            DropIndex("dbo.Services", new[] { "IdServiceProviderUser" });
            DropIndex("dbo.ServiceProviderUsers", new[] { "IdTypeServices" });
            DropIndex("dbo.PaymentTypes", new[] { "IdServiceProviderUser" });
            DropTable("dbo.Services");
            DropTable("dbo.TypeServices");
            DropTable("dbo.ServiceProviderUsers");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.FinalUsers");
            DropTable("dbo.CertificatedImages");
        }
    }
}

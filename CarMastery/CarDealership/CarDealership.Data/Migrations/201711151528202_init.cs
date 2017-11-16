namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        VIN = c.String(),
                        Interior = c.String(),
                        Exterior = c.String(),
                        ImageLocation = c.String(),
                        MSRP = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        IsManual = c.Boolean(nullable: false),
                        CarYear = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Model_ModelId = c.Int(),
                        Sold_SaleId = c.Int(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.CarModels", t => t.Model_ModelId)
                .ForeignKey("dbo.Sales", t => t.Sold_SaleId)
                .Index(t => t.Model_ModelId)
                .Index(t => t.Sold_SaleId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelType = c.String(),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        CarMake_MakeId = c.Int(),
                        ModelStyle_StyleId = c.Int(),
                        UserAdded_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Makes", t => t.CarMake_MakeId)
                .ForeignKey("dbo.Styles", t => t.ModelStyle_StyleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAdded_Id)
                .Index(t => t.CarMake_MakeId)
                .Index(t => t.ModelStyle_StyleId)
                .Index(t => t.UserAdded_Id);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeId = c.Int(nullable: false, identity: true),
                        MakeType = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        UserAdded_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MakeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAdded_Id)
                .Index(t => t.UserAdded_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        StyleId = c.Int(nullable: false, identity: true),
                        StyleType = c.String(),
                    })
                .PrimaryKey(t => t.StyleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        SalePrice = c.Int(nullable: false),
                        PurchaseType = c.String(),
                        SaleDate = c.DateTime(nullable: false),
                        CarId = c.Int(nullable: false),
                        SaleCustomer_CustomerId = c.Int(),
                        SalesPerson_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.SaleCustomer_CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.SalesPerson_Id)
                .Index(t => t.SaleCustomer_CustomerId)
                .Index(t => t.SalesPerson_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        CustomerAddress_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.CustomerAddress_AddressId)
                .Index(t => t.CustomerAddress_AddressId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cars", "Sold_SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "SalesPerson_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sales", "SaleCustomer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CustomerAddress_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Cars", "Model_ModelId", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "UserAdded_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CarModels", "ModelStyle_StyleId", "dbo.Styles");
            DropForeignKey("dbo.CarModels", "CarMake_MakeId", "dbo.Makes");
            DropForeignKey("dbo.Makes", "UserAdded_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Customers", new[] { "CustomerAddress_AddressId" });
            DropIndex("dbo.Sales", new[] { "SalesPerson_Id" });
            DropIndex("dbo.Sales", new[] { "SaleCustomer_CustomerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Makes", new[] { "UserAdded_Id" });
            DropIndex("dbo.CarModels", new[] { "UserAdded_Id" });
            DropIndex("dbo.CarModels", new[] { "ModelStyle_StyleId" });
            DropIndex("dbo.CarModels", new[] { "CarMake_MakeId" });
            DropIndex("dbo.Cars", new[] { "Sold_SaleId" });
            DropIndex("dbo.Cars", new[] { "Model_ModelId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Addresses");
            DropTable("dbo.Customers");
            DropTable("dbo.Sales");
            DropTable("dbo.Styles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Makes");
            DropTable("dbo.CarModels");
            DropTable("dbo.Cars");
        }
    }
}

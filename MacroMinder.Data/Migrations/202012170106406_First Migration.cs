namespace MacroMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                    })
                .PrimaryKey(t => t.RecipeID);
            
            CreateTable(
                "dbo.IngredientLists",
                c => new
                    {
                        IngredientListID = c.Int(nullable: false, identity: true),
                        IngredientMeasurement = c.Double(nullable: false),
                        IngredientUnit = c.Int(nullable: false),
                        IngredientID_IngredientID = c.Int(),
                        RecipeID_RecipeID = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientListID)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID_IngredientID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID_RecipeID)
                .Index(t => t.IngredientID_IngredientID)
                .Index(t => t.RecipeID_RecipeID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        IngredientName = c.String(),
                        Proteins = c.Int(nullable: false),
                        Carbohydrates = c.Int(nullable: false),
                        Fats = c.Int(nullable: false),
                        Calories = c.Int(nullable: false),
                        DietaryFiber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.RecipeSteps",
                c => new
                    {
                        StepID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        StepNumber = c.Int(nullable: false),
                        StepInstruction = c.String(),
                    })
                .PrimaryKey(t => t.StepID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        BMR = c.Int(nullable: false),
                        DietaryGoal = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecipeSteps", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.IngredientLists", "RecipeID_RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.IngredientLists", "IngredientID_IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.Ingredients", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RecipeSteps", new[] { "RecipeID" });
            DropIndex("dbo.Ingredients", new[] { "RecipeID" });
            DropIndex("dbo.IngredientLists", new[] { "RecipeID_RecipeID" });
            DropIndex("dbo.IngredientLists", new[] { "IngredientID_IngredientID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RecipeSteps");
            DropTable("dbo.Ingredients");
            DropTable("dbo.IngredientLists");
            DropTable("dbo.Recipes");
        }
    }
}

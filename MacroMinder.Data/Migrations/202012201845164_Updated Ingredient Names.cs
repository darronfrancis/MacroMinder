namespace MacroMinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedIngredientNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "Protein", c => c.Double(nullable: false));
            AddColumn("dbo.Ingredients", "Fat", c => c.Double(nullable: false));
            DropColumn("dbo.Ingredients", "Proteins");
            DropColumn("dbo.Ingredients", "Fats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Fats", c => c.Double(nullable: false));
            AddColumn("dbo.Ingredients", "Proteins", c => c.Double(nullable: false));
            DropColumn("dbo.Ingredients", "Fat");
            DropColumn("dbo.Ingredients", "Protein");
        }
    }
}

namespace ToDoList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoItems", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoItems", "Category");
        }
    }
}

namespace AdrianPiecykLab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigratin : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "Student_ent_Id", newName: "Student_Id");
            RenameIndex(table: "dbo.Courses", name: "IX_Student_ent_Id", newName: "IX_Student_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Courses", name: "IX_Student_Id", newName: "IX_Student_ent_Id");
            RenameColumn(table: "dbo.Courses", name: "Student_Id", newName: "Student_ent_Id");
        }
    }
}

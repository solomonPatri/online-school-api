using FluentMigrator;
using System.ComponentModel.DataAnnotations.Schema;

namespace online_school_api.Migrations
{
    [Migration(202310101000)] 
    public class CreateStudentAndBookTables : Migration
    {
        public override void Up()
        {
            Create.Table("students")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("age").AsInt32().NotNullable()
                .WithColumn("university").AsString().NotNullable();

            Create.Table("books")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("StudentId").AsInt32().ForeignKey("students", "id").OnDelete(System.Data.Rule.Cascade);

            Create.Table("courses")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("name").AsString().NotNullable()
                    .WithColumn("departament").AsString().NotNullable()
                    .WithColumn("dateCreated").AsDateTime().NotNullable();

            Create.Table("enrolments")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("CourseId").AsInt32().ForeignKey("courses", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("StudentId").AsInt32().ForeignKey("students", "id").OnDelete(System.Data.Rule.Cascade);









        }

        public override void Down()
        {
            Delete.Table("books");
            Delete.Table("students");
            Delete.Table("courses");
            Delete.Table("enrolments");
        }
    }
}
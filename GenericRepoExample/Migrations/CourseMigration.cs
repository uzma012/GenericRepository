using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepoExample.Migrations
{
    public partial class CourseMigration: Migration
        {
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.CreateTable(
                    name: "Course",
                    columns: table => new
                    {
                       course_id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        course_name = table.Column<string>(nullable: true),
                        StudentId = table.Column<int>(nullable: true),
                     
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Course", x => x.course_id);
                    });
            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropTable(
                    name: "Course");
            }
        }
    }


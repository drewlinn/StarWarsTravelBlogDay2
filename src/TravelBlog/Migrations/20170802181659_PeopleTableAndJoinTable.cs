using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelBlog.Migrations
{
    public partial class PeopleTableAndJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Affiliation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Experiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PersonId",
                table: "Experiences",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_People_PersonId",
                table: "Experiences",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_People_PersonId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_PersonId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}

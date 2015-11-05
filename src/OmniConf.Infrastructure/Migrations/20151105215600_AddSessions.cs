using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace OmniConf.Infrastructure.Migrations
{
    public partial class AddSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(nullable: true),
                    ConferenceId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    ImageFile = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.Id);
                });
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Conference",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<decimal>(
                name: "StandardPrice",
                table: "Conference",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "IsActive", table: "Conference");
            migrationBuilder.DropColumn(name: "StandardPrice", table: "Conference");
            migrationBuilder.DropTable("Session");
            migrationBuilder.DropTable("Speaker");
        }
    }
}

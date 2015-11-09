using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace OmniConf.Infrastructure.Migrations
{
    public partial class AddSessions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Session",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ConferenceId", table: "Session");
        }
    }
}

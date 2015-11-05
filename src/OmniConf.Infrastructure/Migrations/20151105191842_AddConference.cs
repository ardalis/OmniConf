using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace OmniConf.Infrastructure.Migrations
{
    public partial class AddConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConferenceEnd = table.Column<DateTime>(nullable: false),
                    ConferenceStart = table.Column<DateTime>(nullable: false),
                    IsSoldOut = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegistrationStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Conference");
        }
    }
}

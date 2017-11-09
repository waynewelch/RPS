using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RpsPolicyApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyNumber = table.Column<int>(type: "int", nullable: false),
                    PrimaryInsuredMailingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryInsuredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryInsuredState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryInsuredZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryInusredCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskConstruction = table.Column<int>(type: "int", nullable: false),
                    RiskState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskYearBuilt = table.Column<int>(type: "int", nullable: false),
                    RiskZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}

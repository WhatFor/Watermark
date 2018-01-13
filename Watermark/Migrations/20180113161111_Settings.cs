using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Watermark.Migrations
{
    public partial class Settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteConfigurationId",
                table: "Site",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "ProductSKU",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayManufacturerRRP",
                table: "ProductPricing",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ManufacturerRRP",
                table: "ProductPricing",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ProductName",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PriceDetail",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "DisplayBasePrice",
                table: "PriceDetail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayEndDateAlert",
                table: "PriceDetail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialPriceActiveOverride",
                table: "PriceDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SpecialPriceBeginningDate",
                table: "PriceDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SpecialPriceEndDate",
                table: "PriceDetail",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrencyConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GlobalCurrency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyConfigurationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_CurrencyConfiguration_CurrencyConfigurationId",
                        column: x => x.CurrencyConfigurationId,
                        principalTable: "CurrencyConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Site_SiteConfigurationId",
                table: "Site",
                column: "SiteConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_CurrencyConfigurationId",
                table: "Configuration",
                column: "CurrencyConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Configuration_SiteConfigurationId",
                table: "Site",
                column: "SiteConfigurationId",
                principalTable: "Configuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Site_Configuration_SiteConfigurationId",
                table: "Site");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "CurrencyConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_Site_SiteConfigurationId",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "SiteConfigurationId",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "DisplayManufacturerRRP",
                table: "ProductPricing");

            migrationBuilder.DropColumn(
                name: "ManufacturerRRP",
                table: "ProductPricing");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PriceDetail");

            migrationBuilder.DropColumn(
                name: "DisplayBasePrice",
                table: "PriceDetail");

            migrationBuilder.DropColumn(
                name: "DisplayEndDateAlert",
                table: "PriceDetail");

            migrationBuilder.DropColumn(
                name: "SpecialPriceActiveOverride",
                table: "PriceDetail");

            migrationBuilder.DropColumn(
                name: "SpecialPriceBeginningDate",
                table: "PriceDetail");

            migrationBuilder.DropColumn(
                name: "SpecialPriceEndDate",
                table: "PriceDetail");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "ProductSKU",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "ProductName",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

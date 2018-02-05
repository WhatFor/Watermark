using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Watermark.Migrations
{
    public partial class LanguageConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialPriceActiveOverride",
                table: "PriceDetail");

            migrationBuilder.RenameColumn(
                name: "PrimaryMedia",
                table: "ProductMedia",
                newName: "Hide");

            migrationBuilder.RenameColumn(
                name: "MediaType",
                table: "ProductMedia",
                newName: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Base64Contents",
                table: "ProductMedia",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "ProductMedia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MediaDescription",
                table: "ProductMedia",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageConfigurationId",
                table: "Configuration",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LanguageConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefaultLanguage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageConfiguration", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_LanguageConfigurationId",
                table: "Configuration",
                column: "LanguageConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_LanguageConfiguration_LanguageConfigurationId",
                table: "Configuration",
                column: "LanguageConfigurationId",
                principalTable: "LanguageConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_LanguageConfiguration_LanguageConfigurationId",
                table: "Configuration");

            migrationBuilder.DropTable(
                name: "LanguageConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_Configuration_LanguageConfigurationId",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "Base64Contents",
                table: "ProductMedia");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "ProductMedia");

            migrationBuilder.DropColumn(
                name: "MediaDescription",
                table: "ProductMedia");

            migrationBuilder.DropColumn(
                name: "LanguageConfigurationId",
                table: "Configuration");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "ProductMedia",
                newName: "MediaType");

            migrationBuilder.RenameColumn(
                name: "Hide",
                table: "ProductMedia",
                newName: "PrimaryMedia");

            migrationBuilder.AddColumn<bool>(
                name: "SpecialPriceActiveOverride",
                table: "PriceDetail",
                nullable: true);
        }
    }
}

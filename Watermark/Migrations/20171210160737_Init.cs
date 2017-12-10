using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Watermark.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lifetime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    End = table.Column<DateTime>(nullable: true),
                    Start = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifetime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSearchEngineOptimisation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSearchEngineOptimisation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSKU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSKU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStockLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LowStockNotification = table.Column<bool>(nullable: false),
                    LowStockThreshold = table.Column<int>(nullable: false),
                    MaxCountInCart = table.Column<int>(nullable: false),
                    NotifyAtStockLevel = table.Column<int>(nullable: false),
                    OutOfStockThreshold = table.Column<int>(nullable: false),
                    StockLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WholeNumberTaxRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<decimal>(nullable: false),
                    IncludesTax = table.Column<bool>(nullable: false),
                    TaxRateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceDetail_TaxRate_TaxRateId",
                        column: x => x.TaxRateId,
                        principalTable: "TaxRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPricing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasePriceId = table.Column<int>(nullable: true),
                    SpecialPriceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPricing_PriceDetail_BasePriceId",
                        column: x => x.BasePriceId,
                        principalTable: "PriceDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPricing_PriceDetail_SpecialPriceId",
                        column: x => x.SpecialPriceId,
                        principalTable: "PriceDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    LifetimeId = table.Column<int>(nullable: true),
                    PriceInformationId = table.Column<int>(nullable: true),
                    ProductNameId = table.Column<int>(nullable: true),
                    ProductSKUId = table.Column<int>(nullable: true),
                    ProductType = table.Column<int>(nullable: false),
                    SearchEngineOptimisationOptionsId = table.Column<int>(nullable: true),
                    StockLevelsId = table.Column<int>(nullable: true),
                    TemplateId = table.Column<int>(nullable: true),
                    TemporaryWithLifetime = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Lifetime_LifetimeId",
                        column: x => x.LifetimeId,
                        principalTable: "Lifetime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductPricing_PriceInformationId",
                        column: x => x.PriceInformationId,
                        principalTable: "ProductPricing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductName_ProductNameId",
                        column: x => x.ProductNameId,
                        principalTable: "ProductName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductSKU_ProductSKUId",
                        column: x => x.ProductSKUId,
                        principalTable: "ProductSKU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductSearchEngineOptimisation_SearchEngineOptimisationOptionsId",
                        column: x => x.SearchEngineOptimisationOptionsId,
                        principalTable: "ProductSearchEngineOptimisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductStockLevel_StockLevelsId",
                        column: x => x.StockLevelsId,
                        principalTable: "ProductStockLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductTemplate_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ProductTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    ProductCategoryId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductConfiguration_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDeliveryOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDeliveryOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDeliveryOption_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Language = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDescription_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MediaType = table.Column<int>(nullable: false),
                    PrimaryMedia = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMedia_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ReviewerId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSettingOverride",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Setting = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSettingOverride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSettingOverride_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceDetail_TaxRateId",
                table: "PriceDetail",
                column: "TaxRateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductId",
                table: "ProductAttribute",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductCategoryId",
                table: "ProductCategory",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfiguration_ProductId",
                table: "ProductConfiguration",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeliveryOption_ProductId",
                table: "ProductDeliveryOption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescription_ProductId",
                table: "ProductDescription",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_ProductId",
                table: "ProductMedia",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_BasePriceId",
                table: "ProductPricing",
                column: "BasePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_SpecialPriceId",
                table: "ProductPricing",
                column: "SpecialPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LifetimeId",
                table: "Products",
                column: "LifetimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceInformationId",
                table: "Products",
                column: "PriceInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductNameId",
                table: "Products",
                column: "ProductNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSKUId",
                table: "Products",
                column: "ProductSKUId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SearchEngineOptimisationOptionsId",
                table: "Products",
                column: "SearchEngineOptimisationOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockLevelsId",
                table: "Products",
                column: "StockLevelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TemplateId",
                table: "Products",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSettingOverride_ProductId",
                table: "ProductSettingOverride",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_ProductId",
                table: "Site",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductConfiguration");

            migrationBuilder.DropTable(
                name: "ProductDeliveryOption");

            migrationBuilder.DropTable(
                name: "ProductDescription");

            migrationBuilder.DropTable(
                name: "ProductMedia");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "ProductSettingOverride");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Lifetime");

            migrationBuilder.DropTable(
                name: "ProductPricing");

            migrationBuilder.DropTable(
                name: "ProductName");

            migrationBuilder.DropTable(
                name: "ProductSKU");

            migrationBuilder.DropTable(
                name: "ProductSearchEngineOptimisation");

            migrationBuilder.DropTable(
                name: "ProductStockLevel");

            migrationBuilder.DropTable(
                name: "ProductTemplate");

            migrationBuilder.DropTable(
                name: "PriceDetail");

            migrationBuilder.DropTable(
                name: "TaxRate");
        }
    }
}

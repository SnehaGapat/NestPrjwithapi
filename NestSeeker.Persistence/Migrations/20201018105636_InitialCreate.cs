using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NestSeeker.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<int>(nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    Landmarks = table.Column<string>(type: "varchar(200)", nullable: false),
                    City = table.Column<string>(type: "varchar(20)", nullable: false),
                    State = table.Column<string>(type: "varchar(100)", nullable: false),
                    BHKTypeId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    ConstructionYear = table.Column<string>(type: "varchar(30)", nullable: false),
                    Amenities = table.Column<string>(type: "varchar(50)", nullable: false),
                    TotalCarpetArea = table.Column<int>(nullable: false),
                    TotalBuiltupArea = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    DirectionId = table.Column<int>(nullable: false),
                    BathroomCount = table.Column<int>(nullable: false),
                    BalconyCount = table.Column<int>(nullable: false),
                    Parking = table.Column<string>(type: "varchar(50)", nullable: false),
                    DocumentId = table.Column<int>(nullable: true),
                    MyFavouritesID = table.Column<int>(nullable: true),
                    RequestsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BHKTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    PropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BHKTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BHKTypes_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    PropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directions_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    Value = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    PropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyTypes_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    PropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MyFavouritesID = table.Column<int>(nullable: true),
                    PropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MyFavourite",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFavourite", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyFavourite_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MyFavourite_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(200)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", nullable: false),
                    Address = table.Column<string>(type: "varchar(500)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Pin = table.Column<string>(type: "varchar(6)", nullable: false),
                    Mobile = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    UserRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    AmountRequested = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    AvailiableOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Request_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    RequestsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionTypes_Request_RequestsID",
                        column: x => x.RequestsID,
                        principalTable: "Request",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BHKTypes_PropertyID",
                table: "BHKTypes",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_PropertyID",
                table: "Directions",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PropertyId",
                table: "Documents",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_MyFavourite_PropertyId",
                table: "MyFavourite",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_MyFavourite_UserRoleId",
                table: "MyFavourite",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BHKTypeId",
                table: "Properties",
                column: "BHKTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_DirectionId",
                table: "Properties",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_DocumentId",
                table: "Properties",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_MyFavouritesID",
                table: "Properties",
                column: "MyFavouritesID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyType",
                table: "Properties",
                column: "PropertyType");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RequestsID",
                table: "Properties",
                column: "RequestsID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StatusId",
                table: "Properties",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_PropertyID",
                table: "PropertyTypes",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PropertyId",
                table: "Request",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TransactionType",
                table: "Request",
                column: "TransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_PropertyID",
                table: "Statuses",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_RequestsID",
                table: "TransactionTypes",
                column: "RequestsID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_MyFavouritesID",
                table: "UserRoles",
                column: "MyFavouritesID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_PropertyID",
                table: "UserRoles",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_UserRoles_OwnerId",
                table: "Properties",
                column: "OwnerId",
                principalTable: "UserRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BHKTypes_BHKTypeId",
                table: "Properties",
                column: "BHKTypeId",
                principalTable: "BHKTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Directions_DirectionId",
                table: "Properties",
                column: "DirectionId",
                principalTable: "Directions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Documents_DocumentId",
                table: "Properties",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_MyFavourite_MyFavouritesID",
                table: "Properties",
                column: "MyFavouritesID",
                principalTable: "MyFavourite",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyType",
                table: "Properties",
                column: "PropertyType",
                principalTable: "PropertyTypes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Request_RequestsID",
                table: "Properties",
                column: "RequestsID",
                principalTable: "Request",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Statuses_StatusId",
                table: "Properties",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_MyFavourite_MyFavouritesID",
                table: "UserRoles",
                column: "MyFavouritesID",
                principalTable: "MyFavourite",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_TransactionTypes_TransactionType",
                table: "Request",
                column: "TransactionType",
                principalTable: "TransactionTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BHKTypes_Properties_PropertyID",
                table: "BHKTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Directions_Properties_PropertyID",
                table: "Directions");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Properties_PropertyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_MyFavourite_Properties_PropertyId",
                table: "MyFavourite");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_Properties_PropertyID",
                table: "PropertyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Properties_PropertyId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Properties_PropertyID",
                table: "Statuses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Properties_PropertyID",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MyFavourite_UserRoles_UserRoleId",
                table: "MyFavourite");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTypes_Request_RequestsID",
                table: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "BHKTypes");

            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "MyFavourite");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "TransactionTypes");
        }
    }
}

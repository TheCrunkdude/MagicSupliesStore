using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicstoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class TablesFirstBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MSDB_Permissions",
                columns: new[] { "ID", "Description", "Permission" },
                values: new object[,]
                {
                    { 1, "All access", "Permiso1" },
                    { 2, "descripcionpermiso", "perm 2" },
                    { 3, "tres", "perm 3" },
                    { 4, "just view", "perm4" },
                    { 5, "mantenimiento", "perm 5" }
                });

            migrationBuilder.InsertData(
                table: "MSDB_Roles",
                columns: new[] { "ID", "Role" },
                values: new object[,]
                {
                    { 1, "Super Admin" },
                    { 2, "User" },
                    { 3, "Viewer" },
                    { 4, "Administrator" },
                    { 5, "Developer" }
                });

            migrationBuilder.InsertData(
                table: "MSDB_RolesPermissions",
                columns: new[] { "ID", "Active", "Permission", "PermissionID", "Role", "RoleID" },
                values: new object[,]
                {
                    { 1, false, "Permiso 1", 1, "Super Admin", 1 },
                    { 2, false, "Permiso 2", 2, "Super Admin", 1 },
                    { 3, false, "Permiso 3", 3, "User ", 2 }
                });

            migrationBuilder.InsertData(
                table: "MSDB_UserRoles",
                columns: new[] { "ID", "Active", "Role", "RoleID", "User", "UserID" },
                values: new object[,]
                {
                    { 1, true, "Super Admin", 1, "user", 1 },
                    { 2, true, "User", 2, "user2", 2 },
                    { 3, true, "Viewer", 3, "user2", 2 }
                });

            migrationBuilder.InsertData(
                table: "MSDB_Users",
                columns: new[] { "ID", "CreationDate", "Mail", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 5, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "user4@example.com", new byte[] { 92, 51, 48, 55, 79, 92, 50, 55, 53, 92, 50, 50, 48, 118, 92, 51, 55, 49, 88, 62, 107, 92, 92, 48, 87, 92, 51, 48, 52, 92, 51, 52, 52, 92, 48, 48, 51, 81, 92, 50, 51, 51, 67, 92, 50, 49, 54, 92, 50, 52, 48, 92, 51, 52, 52, 92, 51, 53, 53, 92, 50, 53, 49, 118, 89, 92, 50, 49, 54, 117, 104, 92, 51, 50, 52, 92, 50, 51, 52, 92, 50, 54, 49, 92, 51, 55, 51, 92, 50, 53, 55, 94, 92, 51, 53, 50, 92, 50, 51, 53, 92, 51, 53, 50, 92, 50, 49, 50, 122, 92, 50, 49, 51, 92, 51, 48, 55, 39, 92, 51, 49, 48, 92, 48, 48, 48, 92, 50, 54, 48, 61, 92, 51, 55, 53, 68, 92, 50, 48, 53, 68, 92, 48, 51, 54, 126, 92, 50, 49, 48, 92, 48, 49, 56, 83, 57, 68, 92, 51, 51, 53 }, new byte[] { 39, 70, 92, 51, 49, 51, 92, 51, 54, 52, 92, 51, 54, 48, 92, 50, 49, 49, 92, 51, 51, 55, 80, 92, 51, 52, 54, 64, 92, 51, 53, 53, 92, 48, 48, 48, 92, 51, 52, 52, 74, 92, 50, 49, 48, 92, 48, 48, 55, 44, 92, 51, 50, 54, 92, 51, 54, 55, 92, 48, 48, 52, 92, 50, 54, 50, 59, 92, 51, 55, 48, 92, 50, 54, 50, 92, 48, 48, 50, 92, 50, 51, 53, 92, 48, 49, 51, 92, 50, 52, 49, 87, 92, 50, 54, 55, 77, 82, 92, 50, 50, 53, 88, 68, 92, 51, 54, 54, 121, 92, 50, 48, 49, 92, 50, 51, 49, 92, 50, 48, 51, 92, 51, 54, 52, 92, 51, 48, 49, 92, 48, 49, 57, 42, 42, 92, 48, 49, 56, 120, 92, 50, 49, 50, 114, 61, 92, 50, 51, 50, 114, 72, 92, 51, 48, 55 }, "user5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MSDB_Permissions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MSDB_Permissions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MSDB_Permissions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MSDB_Permissions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MSDB_Permissions",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MSDB_Roles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MSDB_Roles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MSDB_Roles",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MSDB_Roles",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MSDB_Roles",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MSDB_RolesPermissions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MSDB_RolesPermissions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MSDB_RolesPermissions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MSDB_UserRoles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MSDB_UserRoles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MSDB_UserRoles",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MSDB_Users",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}

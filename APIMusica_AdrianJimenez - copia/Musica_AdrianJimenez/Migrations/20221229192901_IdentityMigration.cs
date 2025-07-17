using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musica_AdrianJimenez.Migrations
{
    public partial class IdentityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80564faa-e92e-49d2-91cb-e388e38adbcc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d18efdf-e00d-4653-b02a-b1e67ec346bb", "7c188a31-ae1e-41d8-a1d2-7f853a49c411" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d18efdf-e00d-4653-b02a-b1e67ec346bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c188a31-ae1e-41d8-a1d2-7f853a49c411");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "589d1e45-65d0-461f-8415-81e26e2764ba", "23084a86-31dd-4bba-993f-ff5f032300ce", "manager", "MANAGER" },
                    { "735a2a98-6dc8-4c67-b378-2d7ddae68999", "ea3f24aa-68db-4688-a034-345960c1030a", "Admin", "ADMIN" },
                    { "aafce66b-996e-4188-9577-9f1fa45c99eb", "8ee480a4-9188-4c15-83ce-461fc436b537", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "apellidos", "codigoPostal", "nombre" },
                values: new object[,]
                {
                    { "235d7f82-ebec-4b77-9028-a5fc450c9c4e", 0, "45046659-53aa-44f8-9f43-b060471b2ef6", "AppUser", "lorena@lorena.com", true, false, null, "LORENA@LORENA.COM", "LORENA@LORENA.COM", null, null, false, "c6d8350e-b753-490e-b7e4-17cb8050ef94", false, "lorena@lorena.com", "Jimenez Mendoza", "28611", "Lorena" },
                    { "a3d729f4-f645-484d-8473-60902ca4000c", 0, "1708c880-d881-4229-b1bb-821a9c6520fc", "AppUser", "adrian@adrian.com", true, false, null, "ADRIAN@ADRIAN.COM", "ADRIAN@ADRIAN.COM", "AQAAAAEAACcQAAAAEL7Kx4tdkpHVxgtnn19IfJ7B6CBPju/++Yc+weQHaEZ55/3LvaG6qFnzykABgB/RmA==", null, false, "c53020d9-81e7-40f9-9af1-fe07c6a49f27", false, "adrian@adrian.com", "Jimenez Mendoza", "28611", "Adrian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aafce66b-996e-4188-9577-9f1fa45c99eb", "235d7f82-ebec-4b77-9028-a5fc450c9c4e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "735a2a98-6dc8-4c67-b378-2d7ddae68999", "a3d729f4-f645-484d-8473-60902ca4000c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "589d1e45-65d0-461f-8415-81e26e2764ba");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aafce66b-996e-4188-9577-9f1fa45c99eb", "235d7f82-ebec-4b77-9028-a5fc450c9c4e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "735a2a98-6dc8-4c67-b378-2d7ddae68999", "a3d729f4-f645-484d-8473-60902ca4000c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "735a2a98-6dc8-4c67-b378-2d7ddae68999");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aafce66b-996e-4188-9577-9f1fa45c99eb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "235d7f82-ebec-4b77-9028-a5fc450c9c4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3d729f4-f645-484d-8473-60902ca4000c");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d18efdf-e00d-4653-b02a-b1e67ec346bb", "0d71415a-4244-49e3-bab6-8263513959d2", "Admind", "ADMIND" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80564faa-e92e-49d2-91cb-e388e38adbcc", "d31b11dd-dcfd-43c5-a7e7-1f8237ec8fbe", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "apellidos", "codigoPostal", "nombre" },
                values: new object[] { "7c188a31-ae1e-41d8-a1d2-7f853a49c411", 0, "7edd377d-6d27-4fca-8aff-a6969a9ab826", "AppUser", "adrian@adrian.com", true, false, null, "ADRIAN@ADRIAN.COM", "ADRIAN@ADRIAN.COM", "AQAAAAEAACcQAAAAEHlhXTE0w9CCqmvA9ccpmVBDsLIlPrkL/B4bwsLyrT+qY7w9F9k7vmdmzHvwgfRnaA==", null, false, "0902d4fc-e3b3-4d55-913f-376fd82b8d58", false, "adrian@adrian.com", "Jimenez Mendoza", "28611", "Adrian" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d18efdf-e00d-4653-b02a-b1e67ec346bb", "7c188a31-ae1e-41d8-a1d2-7f853a49c411" });
        }
    }
}

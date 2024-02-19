using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatafordifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00f50172-e7df-4f73-9267-5c7f2e7672d0"), "Easy" },
                    { new Guid("6cb42f59-9288-42a3-a8be-7053a845591d"), "Medium" },
                    { new Guid("8544923a-9f7c-41df-9471-992802854ac8"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0be3ef6e-e738-49a2-918b-4ac39306b800"), "WGN", "Wellington", null },
                    { new Guid("0c08d2ea-2946-4130-88da-98e42f77f620"), "NTL", "Northland", null },
                    { new Guid("3b53ee0b-a80a-4e5d-8634-1c19944b5aae"), "STL", "Southland", null },
                    { new Guid("5cab363a-50cf-4565-86e3-0bcade0a9e86"), "NSL", "Nelson", null },
                    { new Guid("72c594e7-bd16-47c6-b519-909a61afefb1"), "BOP", "Bay Of Plenty", null },
                    { new Guid("be700c1e-790f-406d-9af9-91a9501869f2"), "AKL", "Auckland", "https://traveltimes.ru/wp-content/uploads/2022/01/okland-1.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("00f50172-e7df-4f73-9267-5c7f2e7672d0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6cb42f59-9288-42a3-a8be-7053a845591d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8544923a-9f7c-41df-9471-992802854ac8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0be3ef6e-e738-49a2-918b-4ac39306b800"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0c08d2ea-2946-4130-88da-98e42f77f620"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3b53ee0b-a80a-4e5d-8634-1c19944b5aae"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5cab363a-50cf-4565-86e3-0bcade0a9e86"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("72c594e7-bd16-47c6-b519-909a61afefb1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("be700c1e-790f-406d-9af9-91a9501869f2"));
        }
    }
}

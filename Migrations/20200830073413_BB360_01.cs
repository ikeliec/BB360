using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BB360TestBrief.Migrations
{
    public partial class BB360_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverLetter",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "JobApplications");

            migrationBuilder.InsertData(
                table: "DocumentTemplates",
                columns: new[] { "Id", "FilePath", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1L, null, "Curriculum Vitae (CV)", new DateTime(2020, 8, 30, 8, 34, 13, 262, DateTimeKind.Local).AddTicks(9240), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(3790) },
                    { 2L, null, "Employment Offer Letter", new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4360), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4370) },
                    { 3L, null, "NYSC Discharge Certificate", new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4380), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4380) },
                    { 4L, null, "Tertiary Certificata", new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390) },
                    { 5L, null, "WAEC/NECO Certificate", new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390) },
                    { 6L, null, "Birth Certificate", new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390) },
                    { 7L, null, "Guarantor Form", new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400) },
                    { 8L, null, "Passport Photograph", new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.AddColumn<string>(
                name: "CoverLetter",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

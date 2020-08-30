using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BB360TestBrief.Migrations
{
    public partial class BB360_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 832, DateTimeKind.Local).AddTicks(9920), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6410), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6430), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6540), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6550), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6550), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6550) });

            migrationBuilder.InsertData(
                table: "DocumentTemplates",
                columns: new[] { "Id", "FilePath", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 9L, "Templates/DRESS CODE POLICY,pdf", "Dress Code Policy", new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6550), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6550) },
                    { 10L, "Templates/EMPLOYEE HANDBOOK.pdf", "Employee Handbook", new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6560), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6560) },
                    { 11L, "Templates/COMPANY CULTURE.pdf", "Company Culture", new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6560), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6560) },
                    { 12L, "Templates/CODE OF CONDUCT POLICY.pdf", "Code of Conduct Policy", new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6560), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6560) },
                    { 13L, "Templates/ANTI-BRIBERY AND CORRUPTION.pdf", "Anti-Bribery and Corruption Policy", new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6560), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6570) },
                    { 14L, "Templates/WHISTLE BLOWING POLICY.pdf", "Whistle Blowing Policy", new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6570), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6570) },
                    { 15L, "Templates/AML-CFT POLICY.pdf", "AML-CFT Policy", new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6570), new DateTime(2020, 8, 30, 14, 26, 23, 839, DateTimeKind.Local).AddTicks(6570) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 262, DateTimeKind.Local).AddTicks(9240), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4360), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4380), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "DocumentTemplates",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400), new DateTime(2020, 8, 30, 8, 34, 13, 269, DateTimeKind.Local).AddTicks(4400) });
        }
    }
}

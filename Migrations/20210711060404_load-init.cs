using Microsoft.EntityFrameworkCore.Migrations;

namespace school_server.Migrations
{
    public partial class loadinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 42, "Adriano" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 2, 39, "Marisa" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 30, "Leonardo" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 2, 25, "Fernando" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "ProfessorId" },
                values: new object[] { 2, "Controle", 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "ProfessorId" },
                values: new object[] { 1, "Otimização", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

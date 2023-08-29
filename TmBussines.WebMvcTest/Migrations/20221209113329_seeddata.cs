using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TmBussines.WebMvcTest.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Description", "IsComplete", "Name" },
                values: new object[,]
                {
                    { 1L, "In Meeting need to discuss some points.", true, "Meeting with managment" },
                    { 2L, "List of this item buy.", false, "Go for shopping" },
                    { 3L, "Here task to ask to do on call.", true, "Call to some one for do some task" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "TodoItem",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}

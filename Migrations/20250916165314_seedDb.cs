using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListCRUD.Migrations
{
    /// <inheritdoc />
    public partial class seedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "arpanparajuli@gmail.com", "ArpanDev", "ArpanDev123@" });

            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "Description", "IsCompleted", "Name", "UserId" },
                values: new object[] { 1, "Playing deadhot like pro", false, "Play deadshot", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

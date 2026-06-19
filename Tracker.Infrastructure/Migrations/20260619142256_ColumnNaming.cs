using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EventTimestamp",
                table: "Events",
                newName: "event_timestamp");

            migrationBuilder.RenameColumn(
                name: "EventSource",
                table: "Events",
                newName: "event_source");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "event_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "event_timestamp",
                table: "Events",
                newName: "EventTimestamp");

            migrationBuilder.RenameColumn(
                name: "event_source",
                table: "Events",
                newName: "EventSource");

            migrationBuilder.RenameColumn(
                name: "event_name",
                table: "Events",
                newName: "EventName");
        }
    }
}

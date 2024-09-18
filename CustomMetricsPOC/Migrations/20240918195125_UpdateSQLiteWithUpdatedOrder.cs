using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomMetricsPOC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSQLiteWithUpdatedOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "registered_date",
                table: "orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "registered_date",
                table: "orders");
        }
    }
}

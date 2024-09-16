using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomMetricsPOC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    product_name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    price = table.Column<decimal>(type: "REAL", precision: 8, scale: 2, nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.order_id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_order_id",
                table: "orders",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}

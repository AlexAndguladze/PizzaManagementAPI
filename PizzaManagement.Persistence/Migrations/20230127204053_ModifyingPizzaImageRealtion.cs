using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifyingPizzaImageRealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Images_ImageId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ImageId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Pizzas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ImageId",
                table: "Pizzas",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Images_ImageId",
                table: "Pizzas",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Images_ImageId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ImageId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ImageId",
                table: "Pizzas",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Images_ImageId",
                table: "Pizzas",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

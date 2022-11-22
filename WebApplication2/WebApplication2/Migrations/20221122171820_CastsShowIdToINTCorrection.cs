using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class CastsShowIdToINTCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Casts_CastId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_CastId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "CastId",
                table: "Shows");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_PersonId",
                table: "Casts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_ShowId",
                table: "Casts",
                column: "ShowId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_People_PersonId",
                table: "Casts",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casts_People_PersonId",
                table: "Casts");

            migrationBuilder.DropForeignKey(
                name: "FK_Casts_Shows_ShowId",
                table: "Casts");

            migrationBuilder.DropIndex(
                name: "IX_Casts_PersonId",
                table: "Casts");

            migrationBuilder.DropIndex(
                name: "IX_Casts_ShowId",
                table: "Casts");

            migrationBuilder.AddColumn<int>(
                name: "CastId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_CastId",
                table: "Shows",
                column: "CastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Casts_CastId",
                table: "Shows",
                column: "CastId",
                principalTable: "Casts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

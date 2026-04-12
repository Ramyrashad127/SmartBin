using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBin.Migrations
{
    /// <inheritdoc />
    public partial class AddCrowdDensityEndPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrowdDensity_Bins_BinId",
                table: "CrowdDensity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrowdDensity",
                table: "CrowdDensity");

            migrationBuilder.RenameTable(
                name: "CrowdDensity",
                newName: "CrowdDensities");

            migrationBuilder.RenameIndex(
                name: "IX_CrowdDensity_BinId",
                table: "CrowdDensities",
                newName: "IX_CrowdDensities_BinId");

            migrationBuilder.AddColumn<float>(
                name: "AiConfidencePercentage",
                table: "CrowdDensities",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrowdDensities",
                table: "CrowdDensities",
                column: "CrowdId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrowdDensities_Bins_BinId",
                table: "CrowdDensities",
                column: "BinId",
                principalTable: "Bins",
                principalColumn: "BinId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrowdDensities_Bins_BinId",
                table: "CrowdDensities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrowdDensities",
                table: "CrowdDensities");

            migrationBuilder.DropColumn(
                name: "AiConfidencePercentage",
                table: "CrowdDensities");

            migrationBuilder.RenameTable(
                name: "CrowdDensities",
                newName: "CrowdDensity");

            migrationBuilder.RenameIndex(
                name: "IX_CrowdDensities_BinId",
                table: "CrowdDensity",
                newName: "IX_CrowdDensity_BinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrowdDensity",
                table: "CrowdDensity",
                column: "CrowdId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrowdDensity_Bins_BinId",
                table: "CrowdDensity",
                column: "BinId",
                principalTable: "Bins",
                principalColumn: "BinId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

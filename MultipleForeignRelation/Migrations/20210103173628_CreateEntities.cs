using Microsoft.EntityFrameworkCore.Migrations;

namespace MultipleForeignRelation.Migrations
{
    public partial class CreateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryStateId = table.Column<int>(nullable: false),
                    BillingStateId = table.Column<int>(nullable: true),
                    ShippingStateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provider_State_BillingStateId",
                        column: x => x.BillingStateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Provider_State_PrimaryStateId",
                        column: x => x.PrimaryStateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provider_State_ShippingStateId",
                        column: x => x.ShippingStateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provider_BillingStateId",
                table: "Provider",
                column: "BillingStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_PrimaryStateId",
                table: "Provider",
                column: "PrimaryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ShippingStateId",
                table: "Provider",
                column: "ShippingStateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_Name",
                table: "State",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}

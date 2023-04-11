using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRABALHOFINALDOPI.Migrations
{
    public partial class T_Ong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ong",
                columns: table => new
                {
                    OngId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Ong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ong", x => x.OngId);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Item = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "DoarOuReceber",
                columns: table => new
                {
                    DoarOuReceberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    QuerDoar = table.Column<bool>(type: "bit", nullable: false),
                    QuerReceber = table.Column<bool>(type: "bit", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    OngId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoarOuReceber", x => x.DoarOuReceberId);
                    table.ForeignKey(
                        name: "FK_DoarOuReceber_Ong_OngId",
                        column: x => x.OngId,
                        principalTable: "Ong",
                        principalColumn: "OngId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoarOuReceber_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoarOuReceber_OngId",
                table: "DoarOuReceber",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_DoarOuReceber_PedidoId",
                table: "DoarOuReceber",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoarOuReceber");

            migrationBuilder.DropTable(
                name: "Ong");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
